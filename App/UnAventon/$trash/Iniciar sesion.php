<?php
if($_POST['email'] != "" && $_POST['clave'] !=""){
	$email= $_POST['email'];
	$clave= $_POST['clave'];
	include('conexion.php');
	$conex = conectar();
	//Inicio de variables de sesión
	session_start();
	
	//Consultar si los datos están guardados en la base de datos
	$consulta= "SELECT * FROM usuarios WHERE email='$email' AND clave='$clave'"; 
	$resultado= mysqli_query($conex,$consulta) or die ('error'); //ejecuta consulta
	$fila=mysqli_fetch_array($resultado);//arreglo con todos los resultados obtenidos de la consulta
	
	//OPCIÓN 1: Si el usuario no existe o los datos son incorrectos
	if (!$fila){ //!$ pregunta negada
		$_SESSION['error'] = '¡Usuario o contraseña incorrecto!';
		header(""); //redirecciona al usuario nuevamente al formulario de acceso
	}
	else{
		//OPCIÓN 2: Usuario logueado correctamente
		//Definimos las variables de sesión y redirigimos a la página de usuario
		$_SESSION['id_usuario'] = $fila['idUsuario']; //SESSION: arreglo donde se guardan variables de sesión - numero único
		$_SESSION['nombre'] = $fila['nombre'];
	
		//generamos dos variables de sesión, en id_usuario ingresamos el id_usuario obtenido que se esta logeando, en nombre ingresamos el nombre de el usuario
		header("");
	}
}
else{
	$_SESSION['error'] = '¡Usuario o contraseña no pueden ser nulas!';
	header(""); 
}
?>
