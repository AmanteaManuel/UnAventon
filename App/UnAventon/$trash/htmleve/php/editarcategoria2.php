<?php 
	if(!session_id()){
		session_start();
	}
	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
	
	$categoria= $_POST['categoria']; //el post encuentra lo que el name manda en editarcategoria linea 42 es un ejemplo
	$idCategoria=$_POST['id'];
	$sql = "UPDATE categorias_productos SET nombre='$categoria' WHERE idCategoriaProducto= $idCategoria";
	if(mysqli_query($conex,$sql)){
		
			$_SESSION['error'] = 'Ha editado correctamente la categoría';
			header("Location:categorias.php");
			exit;
	}
	else{
			$_SESSION['error'] = 'Intentelo de nuevo';
			header("Location:editarcategoria.php?idCategoriaProducto=$idCategoria");
			exit;
	}
		       
?>		   
