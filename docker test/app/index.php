
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <h1>Add a Quote</h1>

    <form id="quoteForm">
        <label for="author">Author:</label><br>
        <input type="text" id="author" name="author"><br>
        <label for="date">Date:</label><br>
        <input type="date" id="date" name="date"><br>
        <label for="content">Quote Text:</label><br>
        <textarea id="content" name="content"></textarea><br>
        <input type="submit" value="Submit">
    </form>
<?php
echo "Heeeeeeeey";
?>
    <script>
        document.getElementById('quoteForm').addEventListener('submit', function(event) {
            event.preventDefault();
    
            var author = document.getElementById('author').value;
            var date = document.getElementById('date').value;
            var content = document.getElementById('content').value;
    
            fetch('http://localhost:5233/quotes', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    author: author,
                    quoteDate: date,
                    content: content,
                }),
            })
            .then(response => response.json())
            .then(data => {
                console.log('Success:', data);
            })
            .catch((error) => {
                console.error('Error:', error);
            });
            fetch('http://localhost:5233/quotes')
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
        });
    </script>
    </body>
</html>
