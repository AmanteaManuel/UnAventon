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
	<title>Reversa | Editar categoría</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<script type="text/javascript" src="css-js/validarcategoria.js"></script>
<body>
	<div id="global">
		<?php
			include('header.php');
			$categoria= $_GET['idCategoriaProducto'];
			$query="SELECT * FROM categorias_productos where idCategoriaProducto=$categoria"; 
			$result=mysqli_query($conex,$query) or die ('error'); 
			$cate= mysqli_fetch_array($result);
		?>
		<article>

			<section>
				<form class="contact_form" action="editarcategoria2.php" method="post" name="contact_form" onsubmit="return runSubmit(this)" enctype="multipart/form-data">
			

					<div> 
						<ul> 
							<li>
								<p><strong>Editar categoría:</strong></p>
								<?php
									if(isset($_SESSION['error'])){
										echo $_SESSION['error'];
										unset($_SESSION['error']);
									}
								?>
							</li>
							<li> 
								<label for="categoria"><em>*</em>Categoría:</label>
								<input name="categoria" title="Categoría" class="validate-select" value="<?php echo $cate['nombre']?>"/>
								<input name="id" type="hidden" value="<?php echo $cate['idCategoriaProducto']?>"/>
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
