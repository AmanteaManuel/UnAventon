<?php 
	
	if(!session_id()){
		session_start();
	}

	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
	
	if( $_POST['idProducto'] == '' or $_POST['categoria'] == '' or  $_POST['nombre'] == '' or $_POST['precio'] == '' or $_POST['fechacaducidad'] == '' or $_POST['descripcion'] == '')
	{ 
	    $_SESSION['error'] = 'Por favor llene todos los campos.';
	    $id=$_POST['idProducto'];
		header("Location:editarproducto.php?idProducto=$id");
		exit;
	}else{ 
		//$_SESSION['id_usuario'] tiene siempre el id del usuario loggeado
		$idUsuario = $_SESSION['id_usuario'];
		$idProducto= $_POST['idProducto'];
		$categoria= $_POST['categoria'];
		$nombre= $_POST['nombre'];
		$precio= $_POST['precio'];
		$fechacaducidad=$_POST['fechacaducidad'];
		$descripcion=$_POST['descripcion'];	
		
		if (!empty($_FILES) && $_FILES['foto']['error'] == 0){
			
			$foto=$_FILES['foto']['tmp_name'];//este es donde esta almacenado el archivo que acabas de subir
			$tipo=$_FILES['foto']['type'];//este es el tipo de archivo que acabas de subir
			$tipoimg= explode("/",$tipo);
			//verificamos el formato de la imagen
			$tam=$_FILES['foto']['size'];
			
			
			if (($tipo=="image/jpeg" || $tipo=="image/pjpeg" || $tipo=="image/gif" || $tipo=="image/bmp" || $tipo=="image/png") && ($tam <= 65536)){
				
				$imagen = addslashes(file_get_contents($_FILES['foto']['tmp_name']));//covierte la imagen para subirla a la bd
				$sql = "UPDATE productos SET  idProducto='$idProducto',idCategoriaProducto='$categoria', idUsuario='$idUsuario', nombre='$nombre', descripcion='$descripcion', precio='$precio', caducidad='$fechacaducidad', contenidoimagen='$imagen', tipoimagen = '$tipoimg[1]' WHERE idProducto = '$idProducto'";
				
			} else{
				
				$_SESSION['error'] = 'La imagen no es correcta.';
				header("Location:editarproducto.php?idProducto=$idProducto");
				exit;
			}
			
		}
		else{
			
			$sql = "UPDATE productos SET idProducto='$idProducto', idCategoriaProducto='$categoria', idUsuario='$idUsuario', nombre='$nombre', descripcion='$descripcion', precio='$precio', caducidad='$fechacaducidad' WHERE idProducto = '$idProducto'";
			
	    } 
	     
	    $result = mysqli_query($conex,$sql);  
	    $_SESSION['error'] = 'Ha sido modificado exitosamente.';
		header("Location:tusproductos.php");
		exit;
	} 
?>		            

