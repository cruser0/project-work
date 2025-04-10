document.addEventListener("DOMContentLoaded", async () => {
    await setCookie();

    if (isTokenExpired()) {
        await RefreshToken();
    }

    const salesContainer = document.getElementById("salesContainer");
    const invoicesContainer = document.getElementById("invoicesContainer");

    const urlParams = new URLSearchParams(window.location.search);
    const bol = urlParams.get("bol");
    const bk = urlParams.get("bk");
    if (bol && bk) {
        await loadInvoices(urlParams);
    }

    await loadSales();
});

async function loadSales() {
    const salesContainer = document.getElementById("salesContainer");
    const saleUrl = `http://localhost:5069/api/sale?SaleCustomerName=${encodeURIComponent(sessionStorage.getItem("name"))}&SaleCustomerCountry=${sessionStorage.getItem("country")}`;
    
    if (isTokenExpired()) {
        await RefreshToken();
    }

    try {
        const response = await fetch(saleUrl, {
            method: 'GET',
            headers: {
                Authorization: `Bearer ${sessionStorage.getItem("accessToken")}`
            }
        });

        const data = await response.json();

        if (!Array.isArray(data)) {
            throw new Error("Unexpected response format");
        }

        salesContainer.innerHTML = "";
        data.forEach(sale => {
            const card = document.createElement("div");
            card.className = "card mb-3";
            card.innerHTML = `
                <div class="card-body">
                    <h3>BoL: ${sale.boLnumber}</h3>
                    <p><strong>Booking:</strong> ${sale.bookingNumber}</p>
                    <p><strong>Date:</strong> ${new Date(sale.saleDate).toLocaleDateString()}</p>
                </div>
            `;

            card.addEventListener("click", () => {
                const urlPostClickParam = new URLSearchParams();
                urlPostClickParam.set('bol', sale.boLnumber);
                urlPostClickParam.set('bk', sale.bookingNumber);
                window.location.search = urlPostClickParam;
            });

            salesContainer.appendChild(card);
        });

    } catch (error) {
        console.error("Error fetching sales:", error);
    }
}

async function loadInvoices(params) {
    const invoicesContainer = document.getElementById("invoicesContainer");
    const bol = params.get("bol");
    const bk = params.get("bk");

    if (!bol || !bk) return;

    const invoiceUrl = `http://localhost:5069/api/customer-invoice/with-total-paid?customerInvoiceSaleBk=${encodeURIComponent(bk)}&customerInvoiceSaleBoL=${encodeURIComponent(bol)}&CustomerName=${encodeURIComponent(sessionStorage.getItem("country"))}&CustomerCountry=${encodeURIComponent(sessionStorage.getItem("name"))}`;
    const headerName = document.getElementById("SaleInv");
    headerName.textContent = `Invoices : ${bk} - ${bol}`;

    if (isTokenExpired()) {
        await RefreshToken();
    }

    try {
        const response = await fetch(invoiceUrl, {
            method: 'GET',
            headers: {
                Authorization: `Bearer ${sessionStorage.getItem("accessToken")}`
            }
        });

        const data = await response.json();
        invoicesContainer.innerHTML = "";

        if (!Array.isArray(data) || data.length === 0) {
            invoicesContainer.innerHTML = "<p>No invoices found for this sale.</p>";
            return;
        }

        data.forEach(inv => {
            const invCard = document.createElement("div");
            invCard.className = "card mb-3 p-3";

            const isPaid = inv.status;

            invCard.innerHTML = `
                <p><strong>Code:</strong> ${inv.customerInvoiceCode || 'N/A'}</p>
                <p><strong>Amount:</strong> € ${Number(inv.invoiceAmount).toLocaleString()}</p>
                <p><strong>Paid:</strong> € ${Number(inv.amountPaid).toLocaleString()} / € ${Number(inv.invoiceAmount).toLocaleString()}</p>
                <p><strong>Date:</strong> ${new Date(inv.invoiceDate).toLocaleDateString()}</p>
                <p><strong>Status:</strong> ${inv.status}</p>
                ${isPaid == "Unpaid" ? `<button type="button" class="btn btn-primary w-100 mt-2">Pay</button>` : ""}
            `;

            if (isPaid == "Unpaid") {
                const btn = invCard.querySelector("button");
                btn.addEventListener("click", () => addTxt(inv, invCard));
            }

            invoicesContainer.appendChild(invCard);
        });

    } catch (error) {
        console.error("Error loading invoices:", error);
    }
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

async function pay(inv, amountToPay) {
    const payUrl = `http://localhost:5069/api/customer-invoice-amount/${encodeURIComponent(inv.amountPaidID)}`;

    const body = {
        AmountPaid: amountToPay,
        MaximumAmount: inv.invoiceAmount,
        CustomerInvoiceID: inv.customerInvoiceId,
        CustomerInvoiceAmountPaidID: inv.amountPaidID
    };

    if (isTokenExpired()) {
        await RefreshToken();
    }

    try {
        const response = await fetch(payUrl, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${sessionStorage.getItem("accessToken")}`
            },
            body: JSON.stringify(body)
        });

        if (!response.ok) {
            const errText = await response.text();
            throw new Error(`Payment failed: ${response.status} - ${errText}`);
        }

        await response.json();
        alert("Payment completed!");

        const params = new URLSearchParams();
        params.set("bol", inv.saleBoL);
        params.set("bk", inv.saleBookingNumber);

        await loadInvoices(params);
    } catch (error) {
        console.error("Error during payment:", error);
    }
}
