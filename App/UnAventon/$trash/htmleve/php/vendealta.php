<?php 
	
	if(!session_id()){
		session_start();
	}

	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
	   
	if(
		$_POST['categoria'] == ''
		or $_POST['nombre'] == ''
		or $_POST['precio'] == ''
		or $_POST['fechapublicacion'] == ''
		or $_POST['fechacaducidad'] == ''
		or $_POST['descripcion'] == ''
		or empty($_FILES)
		or $_FILES['foto']['error'] != 0 //este almacena el codigo de error que resultaría en la subida
		
		
	)
	{ 
	    $_SESSION['error'] = 'Por favor llene todos los campos.';
		header("Location:vende.php");
		exit;
		
	}else{ 


		//$_SESSION['id_usuario'] tiene siempre el id del usuario loggeado
		$idUsuario = $_SESSION['id_usuario'];
		$categoria= $_POST['categoria'];
		$nombre= $_POST['nombre'];
		$precio= $_POST['precio'];
		$fechapublicacion= $_POST['fechapublicacion'];
		$fechacaducidad=$_POST['fechacaducidad'];
		$descripcion=$_POST['descripcion'];	
		$foto=$_FILES['foto']['tmp_name'];//este es donde esta almacenado el archivo que acabas de subir
		$tipo=$_FILES['foto']['type'];//este es el tipo de archivo que acabas de subir
		$tipoimg= explode("/",$tipo);
		//verificamos el formato de la imagen
		if ($tipo=="image/jpeg" || $tipo=="image/pjpeg" || $tipo=="image/gif" || $tipo=="image/bmp" || $tipo=="image/png")
		{
	    $imagen = addslashes(file_get_contents($_FILES['foto']['tmp_name']));//covierte la imagen para subirla a la bd
		$sql = "INSERT INTO productos (idProducto, idCategoriaProducto, idUsuario, nombre, descripcion, precio, publicacion, caducidad, contenidoimagen, tipoimagen) VALUES (null,'$categoria','$idUsuario','$nombre','$descripcion','$precio','$fechapublicacion','$fechacaducidad','$imagen','$tipoimg[1]')";//Se insertan los datos a la base de datos
		
		
		$result = mysqli_query($conex,$sql);
		
		        
		$_SESSION['error'] = 'Carga un producto';
			header("Location:vende.php");
			exit;
	    }
	                    
	} 
?>		            

