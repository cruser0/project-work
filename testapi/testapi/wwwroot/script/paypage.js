document.addEventListener("DOMContentLoaded", () => {
    const urlParams = new URLSearchParams(window.location.search);
    const name = urlParams.get("name");
    const country = urlParams.get("country");

    if (!name || !country) {
        alert("Name and country parameters are required in the URL.");
        return;
    }

    const salesContainer = document.getElementById("salesContainer");
    const invoicesContainer = document.getElementById("invoicesContainer");

    // Construct the URL with query parameters for sales
    const saleUrl = `http://localhost:5069/api/sale?saleCustomerName=${encodeURIComponent(name)}&saleCustomerCountry=${encodeURIComponent(country)}`;

    fetch(saleUrl)
        .then(response => response.json())
        .then(data => {
            if (!Array.isArray(data)) {
                throw new Error("Unexpected response format");
            }
            data.forEach(sale => {
                const card = document.createElement("div");
                card.className = "card";
                card.innerHTML = `
                    <h3>BoL: ${sale.boLnumber}</h3>
                    <p><strong>Booking:</strong> ${sale.bookingNumber}</p>
                    <p><strong>Date:</strong> ${new Date(sale.saleDate).toLocaleDateString()}</p>
                `;
                card.addEventListener("click", () => loadInvoices(sale));
                salesContainer.appendChild(card);
            });
        })
        .catch(error => {
            console.error("Error fetching sales:", error);
        });

    function loadInvoices(sale) {
        // Construct the URL with query parameters for invoices
        const invoiceUrl = `http://localhost:5069/api/customer-invoice?customerInvoiceSaleBk=${encodeURIComponent(sale.bookingNumber)}&customerInvoiceSaleBoL=${encodeURIComponent(sale.boLnumber)}`;

        fetch(invoiceUrl)
            .then(response => response.json())
            .then(data => {
                invoicesContainer.innerHTML = "";
                if (!Array.isArray(data) || data.length === 0) {
                    invoicesContainer.innerHTML = "<p>No invoices found for this sale.</p>";
                    return;
                }

                data.forEach(inv => {
                    const invCard = document.createElement("div");
                    invCard.className = "invoice-card";
                    invCard.innerHTML = `
                        <p><strong>Code:</strong> ${inv.customerInvoiceCode || 'N/A'}</p>
                        <p><strong>Amount:</strong> €${inv.invoiceAmount}</p>
                        <p><strong>Date:</strong> ${new Date(inv.invoiceDate).toLocaleDateString()}</p>
                        <p><strong>Status:</strong> ${inv.status}</p>
                    `;
                    invoicesContainer.appendChild(invCard);
                });
            })
            .catch(error => {
                console.error("Error fetching invoices:", error);
            });
    }
});

