
var button = document.getElementById('navigate-calc__start')

    fetch("/api/GetEmployees",
        {
            method: "post",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "PostParam": "test"
            })
        })
        .then((response) => response.json())
        .then((data) => {
            data = data.value
            console.log(data.titles[0])
            console.log(data.titles[1])
        });