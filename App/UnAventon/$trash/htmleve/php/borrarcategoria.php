	   
<?php 
	
	if(!session_id()){
		session_start();
	}
	
	
	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
	
	$idCategoriaProducto= $_GET['idCategoriaProducto'];
	
	$sql="SELECT * FROM productos where idCategoriaProducto = $idCategoriaProducto";
	$productos=	mysqli_query($conex,$sql);
	
	if(mysqli_num_rows($productos) > 0){ 
		$_SESSION['error'] = 'No puede eliminar esta categoría porque tiene productos asociados.';
		header("Location:categorias.php");
		exit;
	}

	else{
		$sql = "DELETE FROM categorias_productos WHERE idCategoriaProducto = '$idCategoriaProducto'";
		if(mysqli_query($conex,$sql)){
		
			$_SESSION['error'] = 'Ha borrado correctamente la categoría';
			header("Location:categorias.php");
			exit;
		}
		else{
			$_SESSION['error'] = 'Intentelo de nuevo';
			header("Location:categorias.php");
			exit;
		}
		
	}       
		

?>		            
