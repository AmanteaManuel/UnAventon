<?php
	if(!session_id()){ //para ver si la sesión está iniciada
		session_start();
	}
	include('usuario.php');
	$user= new usuario(); //instancia de una clase
	$user->estaRegistrado();
?>
<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Categoría nueva</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<script type="text/javascript" src="css-js/validarcategoria.js"></script>
<body>
	<div id="global">
		<?php
			include('header.php');
			$query="SELECT * FROM categorias_productos"; 
			$result=mysqli_query($conex,$query) or die ('error'); 
		?>
		<?php
				if(isset($_SESSION['error'])){ // para que aparezca el mensaje
					echo $_SESSION['error'];
					unset($_SESSION['error']);
				}
		?>
		<article>

			<section>
					<form class="contact_form" action="categoriaalta2.php" method="post" name="contact_form" onsubmit="return runSubmit(this)" enctype="multipart/form-data">
			

					<div> 
						<ul> 
							<li>
								<p><strong>Categoría nueva:</strong></p>
							</li>
							<li> 
								<label for="categoria">Categoría:</label>
								<input type="text" name="categoria" required />
							</li> 	
							<li>
								<button class="submit" type="submit">AGREGAR</button>
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
