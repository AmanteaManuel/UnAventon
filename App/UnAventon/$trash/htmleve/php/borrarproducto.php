<?php 
	
	if(!session_id()){
		session_start();
	}
	
	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();

		$idProducto= $_GET['idProducto'];
		$sql = "DELETE FROM productos WHERE idProducto = '$idProducto'";
		
		$result = mysqli_query($conex,$sql);
		
		        
		$_SESSION['error'] = '';
			header("Location:tusproductos.php");
			exit;

?>		            

