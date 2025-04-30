document.getElementById('loadDataBtn').addEventListener('click', function () {
    const url = this.dataset.url;
    const xhr = new XMLHttpRequest();

    xhr.open('GET', url, true);

    xhr.onload = function () {
        if (xhr.status === 200) {
            var data = JSON.parse(xhr.responseText);
            var tbody = document.querySelector("#usersTable tbody");
            tbody.innerHTML = "";
            data.forEach(function (user) {
                var row = document.createElement("tr");

                row.innerHTML = `
                    <td class="userId" style="display:none;">${user.id}</td>
                    <td>${user.name}</td>
                    <td>${user.username}</td>
                    <td>${user.email}</td>
                    <td>${user.phone}</td>
                    <td>${user.website}</td>
                    <td>${user.address?.street ?? ''}</td>
                    <td>${user.address?.suite ?? ''}</td>
                    <td>${user.address?.city ?? ''}</td>
                    <td>${user.address?.zipcode ?? ''}</td>
                    <td>${user.address.geo?.lat ?? ''}</td>
                    <td>${user.address.geo?.lng ?? ''}</td>
                    <td><textarea name="Note" class="form-control">${user.note ?? ''}</textarea></td>
                    <td><input type="checkbox" name="IsActive" ${user.isActive ? 'checked' : ''} /></td>
                `;

                tbody.appendChild(row);
            });

            document.getElementById("usersTable").style.display = "block";
        } else {
            alert('Error loading data!');
        }
    };

    xhr.onerror = function () {
        alert('Error loading data!');
    };

    xhr.send();
});

document.getElementById("saveAllBtn").addEventListener("click", function () {
    const url = this.dataset.url;
    const users = [];

    document.querySelectorAll("#usersTable tbody tr").forEach(function (row) {
        const user = {
            Id: row.querySelector(".userId")?.textContent.trim(),
            Name: row.cells[1].textContent.trim(),
            Username: row.cells[2].textContent.trim(),
            Email: row.cells[3].textContent.trim(),
            Phone: row.cells[4].textContent.trim(),
            Website: row.cells[5].textContent.trim(),
            Note: row.querySelector('textarea[name="Note"]')?.value ?? "",
            IsActive: row.querySelector('input[name="IsActive"]')?.checked ?? false,
            Address: {
                Street: row.cells[6].textContent.trim(),
                Suite: row.cells[7].textContent.trim(),
                City: row.cells[8].textContent.trim(),
                Zipcode: row.cells[9].textContent.trim(),
                Geo: {
                    Lat: row.cells[10].textContent.trim(),
                    Lng: row.cells[11].textContent.trim()
                }
            }
        };
        users.push(user);
    });

    fetch('/User/SaveData', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(users)
    })
    .then(response => {
        if (!response.ok) throw new Error('Network response was not ok');
        return response.text();
    })
    .then(() => {
        alert("Users saved successfully!");
        document.getElementById("usersTable").style.display = "none";
        window.location.href = "/User/Index";
    })
    .catch(() => {
        alert("Error saving users! Please try again later.");
    });
});