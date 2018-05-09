<?php

	include('conexion.php');
	$conex = conectar();


//Iniciar Sesión
	if(!session_id()){
		session_start();
	}
//Validar si se está ingresando con sesión correctamente

if (isset($_SESSION['id_usuario'])){
	$id_usuario= $_SESSION['id_usuario'];
	$consulta="SELECT nombre, apellido, email, telefono FROM usuarios WHERE idUsuario='$id_usuario'";
	$resultado=mysqli_query($conex,$consulta) or die('Error');
	$usuario=mysqli_fetch_array($resultado);
	
}

?>
<header>
		
			<div class="banner">
				<a href="index.php" title="Volver al inicio">
					<img class="banner" src="../img/banner.png" alt="Reversa">
				</a>
			</div>
			<?php
			if(isset($_SESSION['id_usuario'])){ ?>  
				<table width="700" border="0" align="right" cellpadding="0" cellspacing="0">
				  <tr>
				    <td align="center";><a class="salir"; href="desconectar_usuario.php">Cerrar sesión</a></td>
				  </tr>
				  <tr>
				    <td align="center">&nbsp;</td>
				  </tr>
				</table>	
			<?php
			}
				include ('menu.php');
			?>
</header>
