<?php

	 class usuario{ 
	 	 var $usu; //atributos clase usuario
	 	function ingresar($email, $clave, $conex){

	 		try{
		 		if($email != "" && $clave != ""){
					
					

					//Inicio de variables de sesión
					if(!session_id()){
						session_start();
					}
					
					//Consultar si los datos están guardados en la base de datos
					$consulta= "SELECT * FROM usuarios WHERE email='$email' AND clave='$clave'"; 
					$resultado= mysqli_query($conex,$consulta) or die ('error'); //ejecuta consulta
					$fila=mysqli_fetch_array($resultado);//arreglo con todos los resultados obtenidos de la consulta
					
					//OPCIÓN 1: Si el usuario no existe o los datos son incorrectos
					if (!$fila){ //!$ pregunta negada
						throw new Exception("Error al completar datos");
					}
					else{

						//OPCIÓN 2: Usuario logueado correctamente
						//Definimos las variables de sesión y redirigimos a la página de usuario
						$_SESSION['id_usuario'] = $fila['idUsuario']; //SESSION: arreglo donde se guardan variables de sesión - numero único
						$_SESSION['nombre'] = $fila['nombre'];
					
						//generamos dos variables de sesión, en id_usuario ingresamos el id_usuario obtenido que se esta logeando, en nombre ingresamos el nombre de el usuario
						header("Location:backend.php");
					}
					
				}
				else {
					throw new Exception("Error al completar datos");
					
				}
			}
			catch (Exception $e) { //si llego al catch es porque tuve un error
					
					$_SESSION['error'] = $e->getMessage(); 
					header("Location:ingresar.php");	
				
			}

		}
	 	function desconectar(){
			if(isset($_SESSION['id_usuario'])){	
				unset($_SESSION['id_usuario']); //borro la variable nombre
				session_destroy(); //destruye la sesion
			}
			header("location:ingresar.php");
	 	}
	 	function estaRegistrado(){
			try{
				if(!isset($_SESSION['id_usuario'])){
					throw new Exception();
				}
			}
			catch (Exception $e){
				header('Location:ingresar.php');
			}

	 	}
	 }
?>
