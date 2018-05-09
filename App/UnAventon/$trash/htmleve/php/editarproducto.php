<?php
	if(!session_id()){ //para ver si la sesión está iniciada
		session_start();
	}
?>
<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Editar producto</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<script type="text/javascript" src="css-js/editarprodvalidar.js"></script>
<body>
	<div id="global">
	<?php
		include('header.php');
		
		include('usuario.php');
		$user= new usuario(); //instancia de una clase
		$user->estaRegistrado();
		
		$idProducto= $_GET['idProducto'];
		$query="SELECT * FROM productos where idProducto = $idProducto"; 
		$result=mysqli_query($conex,$query) or die ('error'); 
		$producto= mysqli_fetch_array($result);
	?>
	
	<article>
		<section>
				<form class="contact_form" action="editarproducto2.php" method="post" name="contact_form" onsubmit="return runSubmit(this)" enctype="multipart/form-data">
					<div> 
						<input value="<?php echo $producto['idProducto']; ?>" type="hidden" name="idProducto"/>
						<ul>
							<li> 
								<h3>EDITAR PRODUCTO</h3>
								<?php
									if(isset($_SESSION['error'])){
										echo $_SESSION['error'];
										unset($_SESSION['error']);
									}

								?>
								<span class="required_notification">* Datos requeridos</span> 
							</li>
							<li> 
								<label for="categoria"><em>*</em>Categoría:</label>
								<select name="categoria" title="Categoría" class="validate-select"/>
									<option value="todos">Seleccione una opcion</option>
									<?php 
										/* hacer consulta para devolver categorias */
										$categorias="SELECT * FROM categorias_productos"; 
										$result2=mysqli_query($conex,$categorias) or die ('error');
										while($row = mysqli_fetch_array($result2)){
																		
												if( $producto['idCategoriaProducto'] == $row['idCategoriaProducto']){
													$selected = 'selected';
												}else {
													$selected = "";
												}
												
										?>
										<option  <?php echo $selected ?> value="<?php echo $row['idCategoriaProducto']?>"><?php echo $row['nombre'] ?></option>
										<?php 
										}
									?>
								</select>
							</li>
								
							<li> 
								<label for="nombre"><em>*</em>Producto:</label>
								<input value="<?php echo $producto['nombre']; ?>" type="text" name="nombre"/>
							</li>
							<li> 
								<label for="precio"><em>*</em>Precio:</label>
								<input value="<?php echo $producto['precio'];?>" type="text" name="precio"/>
							</li> 
							<li> 
								<label for="fechacaducidad"><em>*</em>Fecha caducidad:</label>
								<input value="<?php echo $producto['caducidad'];?>" type="date" inputmode="numeric"  name="fechacaducidad" title="Día/Mes/Año" required/>
							</li>
							<li> 
								<label for="descripcion"><em>*</em>Descripción:</label>
								<input value="<?php echo $producto['descripcion'];?>" type="text" name="descripcion"  rows=5 cols=20/>
							</li>
							<li>
								<div>
									<label for="foto"><em>*</em>Foto:</label>
									<input type="file" name="foto"></input>
								</div>
								<div>
									<label> Imagen actual:</label>
									<img class="imagenproductos" src="mostrarImagen.php?idProducto=<?php echo $producto['idProducto']?>">
								</div>
							</li>
							<li>
								<button class="submit" type="submit">GUARDAR</button>
							</li>						
						</ul> 
					</div>
				</form>							
		</section>
		
	</article>
	<?php 
			include('footer.php');
	?>
</body>

</html>
