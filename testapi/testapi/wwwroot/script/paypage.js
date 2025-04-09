

document.addEventListener("DOMContentLoaded", () => {
    if(isTokenExpired()){
        window.location.replace("http://localhost:5069/login.html");
    }    
    const urlParams = new URLSearchParams(window.location.search);
    if(urlParams.get("inv")!=undefined){
        
    }
    const salesContainer = document.getElementById("salesContainer");
    const invoicesContainer = document.getElementById("invoicesContainer");
    const saleUrl = `http://localhost:5069/api/sale`;
    console.log("token scaduto: "+isTokenExpired());
    if(isTokenExpired()){
        RefreshToken();
    }
    fetch(saleUrl, {
        method: 'GET',
        headers: {
          Authorization: `Bearer ${sessionStorage.getItem("accessToken")}`
        }
      })
        .then(response => response.json())
        .then(data => {
            if (!Array.isArray(data)) {
                throw new Error("Unexpected response format");
            }
            data.forEach(sale => {
                const card = document.createElement("div");
                card.className = "card mb-3";  
                card.innerHTML = `
                    <h3>BoL: ${sale.boLnumber}</h3>
                    <p><strong>Booking:</strong> ${sale.bookingNumber}</p>
                    <p><strong>Date:</strong> ${new Date(sale.saleDate).toLocaleDateString()}</p>
                `;
                card.addEventListener("click", () =>{
                    const urlPostClickParam = new URLSearchParams(window.location.search);
                    urlPostClickParam.set('bol', sale.boLnumber);
                    urlPostClickParam.set('bk', sale.bookingNumber);
                    window.location.search = urlPostClickParam;
                    loadInvoices(urlPostClickParam)
                });
                    
                salesContainer.appendChild(card);
            });
        })
        .catch(error => {
            console.error("Error fetching sales:", error);
        });

        function loadInvoices(urlPostClickParam) {
            const bol=urlPostClickParam.get("bol");
            const bk=urlPostClickParam.get("bk");
            const invoiceUrl = `http://localhost:5069/api/customer-invoice/with-total-paid?customerInvoiceSaleBk=${encodeURIComponent(bk)}&customerInvoiceSaleBoL=${encodeURIComponent(bol)}`;
            const headerName = document.getElementById("SaleInv");
            headerName.textContent = `Invoices : ${bk} - ${bol}`;
            if(isTokenExpired()){
                RefreshToken();
            }
            fetch(invoiceUrl, {
                method: 'GET',
                headers: {
                  Authorization: `Bearer ${sessionStorage.getItem("accessToken")}`
                }
              })
                .then(response => response.json())
                .then(data => {
                    invoicesContainer.innerHTML = "";
                    if (!Array.isArray(data) || data.length === 0) {
                        invoicesContainer.innerHTML = "<p>No invoices found for this sale.</p>";
                        return;
                    }
        
                    data.forEach(inv => {
                        const invCard = document.createElement("div");
                        invCard.className = "card mb-3 p-3";
        
                        const isPaid = inv.amountPaid >= inv.invoiceAmount;
        
                        invCard.innerHTML = `
                            <p><strong>Code:</strong> ${inv.customerInvoiceCode || 'N/A'}</p>
                            <p><strong>Amount:</strong> € ${new Number(inv.invoiceAmount).toLocaleString()}</p>
                            <p><strong>Paid:</strong> € ${new Number(inv.amountPaid).toLocaleString()} / € ${new Number(inv.invoiceAmount).toLocaleString()}</p>
                            <p><strong>Date:</strong> ${new Date(inv.invoiceDate).toLocaleDateString()}</p>
                            <p><strong>Status:</strong> ${inv.status}</p>
                            ${!isPaid ? `<button type="button" class="btn btn-primary w-100 mt-2">Pay</button>` : ""}
                        `;
        
                        if (!isPaid) {
                            const btn = invCard.querySelector("button");
                            btn.addEventListener("click", () => addTxt(inv, invCard));
                        }
        
                        invoicesContainer.appendChild(invCard);
                    });
                })
                .catch(error => {
                    console.error("Error fetching invoices:", error);
                });
        }
        
        function addTxt(inv, card) {
            const defaultAmount = (inv.invoiceAmount - inv.amountPaid).toFixed(2);
        
            if (card.querySelector("input")) return;
        
            const input = document.createElement("input");
            input.type = "number";
            input.step = "0.01";
            input.className = "form-control my-2";
            input.placeholder = "Enter amount to pay";
            input.value = defaultAmount;
        
            const payBtn = document.createElement("button");
            payBtn.className = "btn btn-success w-100";
            payBtn.textContent = "Complete Payment";
        
            payBtn.addEventListener("click", () => {
                const amount = parseFloat(input.value);
                if (isNaN(amount) || amount <= 0 || amount > (inv.invoiceAmount - inv.amountPaid)) {
                    alert("Invalid amount. Must be positive and not exceed remaining balance.");
                    return;
                }
        
                pay(inv, amount);
            });
        
            card.appendChild(input);
            card.appendChild(payBtn);
        }
        
        function pay(inv, amountToPay) {
            const payUrl = `http://localhost:5069/api/customer-invoice-amount/${encodeURIComponent(inv.amountPaidID)}`;
        
            const body = {
                AmountPaid: amountToPay,
                MaximumAmount: inv.invoiceAmount,
                CustomerInvoiceID: inv.customerInvoiceId,
                CustomerInvoiceAmountPaidID: inv.amountPaidID
            };
            console.log(body);
            if(isTokenExpired()){
                RefreshToken();
            }
            fetch(payUrl, {
                method: "PUT",
                Authorization: `Bearer ${sessionStorage.getItem("accessToken")}`,
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(body)
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Payment failed");
                }
                return response.json();
            })
            .then(data => {
                alert("Payment completed!");
                loadInvoices({ bookingNumber: inv.saleBookingNumber, boLnumber: inv.saleBoL }); 
            })
            .catch(error => {
                console.error("Payment error:", error);
                alert("Payment failed. Please try again.");
            });
        }
        function isTokenExpired() {
            const exp = sessionStorage.getItem("exp");
            if (!exp) {
                console.error("Expiration time not found.");
                return true;
            }
            const currentTime = Math.floor(Date.now() / 1000);
            return exp < currentTime;
        }
        
});
