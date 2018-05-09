<?php
//Proceso de conexión con la base de datos
function conectar(){
	/* para que funcione local*/
	
	/*$conex= mysqli_connect("localhost","root","","grupo04")
		or die("No se pudo realizar la conexion");*/
	/**/
	$conex= mysqli_connect("localhost","grupo04","oaJaesh0","grupo04")
		or die("No se pudo realizar la conexion");
		mysqli_set_charset($conex, 'utf8'); 
	return $conex;
}
	
?>
	
