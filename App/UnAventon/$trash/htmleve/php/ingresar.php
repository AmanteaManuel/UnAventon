<?php
	if(!session_id()){
		session_start(); 
		if( isset($_SESSION['id_usuario'])){
			header('location: micuenta.php');
		}
	}
?>
<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Ingresar</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<script type="text/javascript" src="css-js/ingresarvalidar.js"></script>
<body>
	<div id="global">
	<?php
		include('header.php');
	?>
		<article>
			
			<section>
				<form action="script_acceso_usuario.php" class="contact_form" method="post" name="contact_form" onsubmit="return runSubmit(this)">
					<div> 
						<ul>
							<li> 
								<h3>CLIENTES REGISTRADOS</h3>
								<p>Si tenés una cuenta registrada, ingresá tus datos</p>
								<?php if( isset($_SESSION['error']) ){
									echo ($_SESSION['error']);
								}
								 if( isset($_SESSION['mensaje']) ){
									echo ($_SESSION['mensaje']);
								}
								unset($_SESSION['error']);
								unset($_SESSION['mensaje']);
								?>
								<span class="required_notification">* Datos requeridos</span> 
							</li>
							<li> 
								<label for="name"><em>*</em>Nombre usuario:</label>
								<input type="text" name="email" required/>
							</li>
							<li>
								<div class="field">
                        			<label for="password" class="required"><em>*</em>Clave:</label>
                        			
                        			<div class="input-box">
                            			<input type="password" name="clave" id="password" title="Contraseña"  required/>
                        			</div> 
                    			</div>
                    		</li>
                    		<li>
								<button class="submit" type="submit">INGRESAR</button>
							</li> 							
						</ul> 
					</div>
				</form>						
			</section>	
		</article>
		<?php 
			include('footer.php');
		?>
		
	</div>
</body>

</html>
