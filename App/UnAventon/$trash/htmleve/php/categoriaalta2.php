<?php 
	if(!session_id()){
		session_start();
	}
	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
					    
	if($_POST['categoria'] == '')
	{ 
	    $_SESSION['error'] = 'Por favor llene el campo.';
		header("Location:categoriaalta.php");
		exit;
	} else { 
		
		$categoria= $_POST['categoria'];
		$sql = "INSERT INTO categorias_productos (nombre) VALUES ('$categoria')"; //nombre-categoriaProducto
		$result = mysqli_query($conex,$sql); 

		$_SESSION['error'] = 'Carga otra categoría';
			header("Location:categorias.php");
			exit;                   
	} 
?>		            
