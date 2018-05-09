<?php 
	
	include('conexion.php');
	$conex = conectar();
	
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
	
					    
	if($_POST['nombre'] == '' or $_POST['apellido'] == '' or $_POST['email'] == '' or $_POST['telefono'] == '')
	{ 
	    $_SESSION['error'] = 'Por favor llene todos los campos.';
		header("Location:editarinformacion.php");
		exit;
	} else { 
		
		if(!session_id()){
			session_start();
		}
		
		$idUsuario=$_SESSION['id_usuario'];
		$email=$_POST['email'];
		$sql= "SELECT * FROM usuarios WHERE email='$email' and idUsuario<>'$idUsuario'";
		$result = mysqli_query($conex,$sql); 
		if(mysqli_num_rows($result) >= 1 )//cant de filas que me devuelve la consulta
		{ 
			$_SESSION['error'] = 'Ya existe este email.';
			header("Location:editarinformacion.php");
			exit;
		}
		else{ 
			$nombre= $_POST['nombre'];
			$apellido= $_POST['apellido'];
			$email=$_POST['email'];
			$telefono= $_POST['telefono'];
			$sql = "UPDATE usuarios SET nombre='$nombre', apellido='$apellido', email='$email', telefono='$telefono' WHERE idUsuario='$idUsuario'";
			$result = mysqli_query($conex,$sql);//ejecuto la consulta
			$_SESSION['mensaje'] = 'Haz editado correctamente los datos.';
			header("Location:micuenta.php");
			exit;
		} 
	}		            
?> 
