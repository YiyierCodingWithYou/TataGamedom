async function loadIntoTable(url) {

    const response = await fetch(url);
    const data = await response.json();


    const thead = document.querySelector("table > thead > tr");
    const tbody = document.querySelector("table > tbody");

    Object.keys(data[0]).forEach(attr => {
        thead.innerHTML +=
            `<th>${attr}</th>`;
    });

    data.forEach(ele => {
        let append = "";
        append += "<tr>";
        Object.values(ele).forEach(entry => {
            append += `<td>${entry}</td>`;
        });
        append += "</tr>";
        tbody.innerHTML += append;
    });
}

loadIntoTable("Supplier.json", document.querySelector("table"));
