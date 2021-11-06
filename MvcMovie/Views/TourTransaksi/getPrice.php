<?php
$mysqli = new mysqli("localhost", "root", "khoirul", "newtour");
if($mysqli->connect_error) {
  exit('Could not connect');
}

$sql = "SELECT Price
FROM destinations WHERE Id = ?";

$stmt = $mysqli->prepare($sql);
$stmt->bind_param("s", $_GET['q']);
$stmt->execute();
$stmt->store_result();
$stmt->bind_result($Price);
$stmt->fetch();
$stmt->close();

echo "<table>";
echo "<tr>";
echo "<th>Price</th>";
echo "<td>" . $Price . "</td>";
?>