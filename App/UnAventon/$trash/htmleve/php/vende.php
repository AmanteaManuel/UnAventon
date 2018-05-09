<?php
	if(!session_id()){ //para ver si la sesión está iniciada
		session_start();
	}
?>
<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Productos</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<script type="text/javascript" src="css-js/validarvende.js"></script>
<body>
	<div id="global">
		<?php
			include('header.php');
			
			include('usuario.php');
			$user= new usuario(); //instancia de una clase
			$user->estaRegistrado();
			
			$query="SELECT * FROM categorias_productos"; 
			$result=mysqli_query($conex,$query) or die ('error'); 
		?>
		<?php
				if(isset($_SESSION['error'])){
					echo $_SESSION['error'];
					unset($_SESSION['error']);
				}
		?>
		<article>

			<section>
					<p><strong>¿Qué quieres publicar?</strong></p>
					<form class="contact_form" action="vendealta.php" method="post" name="contact_form" onsubmit="return runSubmit(this)" enctype="multipart/form-data">
			
						<select name="categoria" title="Categoría" class="validate-select"/>
							<option value="todos">Seleccione una opcion</option>
							<?php 
								while($row = mysqli_fetch_array($result)){?>
								<option value="<?php echo $row['idCategoriaProducto']?>"><?php echo $row['nombre'] ?></option>
								<?php 
								}
							?>
						</select>

					<div> 
						<ul> 
							<li>
								<p><strong>Detalla y publica tu aviso</strong></p>
							</li>
							<li> 
								<label for="nombre">Título producto:</label>
								<input type="text" name="nombre" required />
							</li> 
							<li>
								<label for="precio">Precio en pesos:</label>
								<input type="text" name="precio" required />
							</li>
							<li>
								<label for="fechapublicacion">Fecha publicación:</label>
								<input type="date" inputmode="numeric" name="fechapublicacion" value="" title="Día/Mes/Año" required>
							</li>
							<li>
								<label for="fechacaducidad">Fecha caducidad:</label>
								<input type="date" inputmode="numeric"  name="fechacaducidad" value="" title="Día/Mes/Año" required>
							</li>
							<li> 
								<label for="descripcion">Descripción:</label>
								<textarea type="text" name="descripcion"  rows=5 cols=20 > </textarea>
							</li>
							<li>
								<div>
									<label for="foto">Foto:</label>
									<input type="file" name="foto"></input>
								</div>
							</li>	
							<li>
								<button class="submit" type="submit">PUBLICA</button>
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
