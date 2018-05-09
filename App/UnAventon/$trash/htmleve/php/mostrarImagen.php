<?php

	$id=$_GET['idProducto'];
	
	$conex= mysqli_connect("localhost","grupo04","oaJaesh0","grupo04")
		or die("No se pudo realizar la conexion");
	$sql="SELECT contenidoimagen, tipoimagen FROM productos WHERE idProducto = $id";

	$result=mysqli_query($conex, $sql);
	$row=mysqli_fetch_array($result);
	mysqli_close($conex);
	header("Content-type:image/".$row['tipoimagen']);
	echo $row['contenidoimagen'];
?>
