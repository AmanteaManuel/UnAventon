<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Tus productos</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<body>
	<div id="global">
		<?php
			include('header.php');
			include('usuario.php');
			$user= new usuario(); //instancia de una clase
			$user->estaRegistrado();

			if(!session_id()){ //para ver si la sesión está iniciada
				session_start();
			}

			$idUsuario=$_SESSION['id_usuario'];
			
		?>

		<section>
				<p><strong>Tus productos:</strong></p>
				<?php
					if(isset($_SESSION['error'])){
						echo $_SESSION['error'];
						unset($_SESSION['error']);
					}

				?>
				<div class="tiendatabla">
					<table id="tablatienda">
						<thead>
                			<tr>
                    			<th>
                      				Foto
                    			</th>
                    			<th>
                       				Producto
                    			</th>
                    			<th>
                    				<div id="categoria">
										Categoría
									</div>
                    			</th>
                    			<th>
									<div class="fechaprecio">
										<?php $orden_fecha='asc'; $orden_precio='asc';
										
											$fecha_actual = date("Y-m-d");
											$query="SELECT p.idProducto, p.nombre as nombre, c.nombre as categoria, p.caducidad, p.precio FROM  `productos` p INNER JOIN categorias_productos c ON p.idCategoriaProducto = c.idCategoriaProducto where p.idUsuario = $idUsuario";
												
											if( isset($_GET["gender"]) &&($_GET["gender"] != 'todos')){
												$categoria = $_GET["gender"];
												$query = $query . " and p.idCategoriaProducto = $categoria";
												
												
												
											}
											if( isset($_GET["producto"])){
												$nombre = $_GET["producto"];
												$query = $query . " and p.nombre LIKE '%$nombre%' ";
												
											}
											//  LIKE '%short%'
											
											if( isset($_GET["orden_fecha"]) ){
												$fechacaducidad = $_GET["orden_fecha"];
												$query = $query . " order by p.caducidad $fechacaducidad" ;
												if ($fechacaducidad == 'asc'){
													$orden_fecha='desc';
												}
											}
											
											if( isset($_GET["orden_precio"]) ){
												$precio = $_GET["orden_precio"];
												$query = $query . " order by p.precio $precio" ;
												if ($precio == 'asc'){
													$orden_precio='desc';
												}
											}
												
														
											$result=mysqli_query($conex,$query) or die ('error');
											
										?>				
						 
										<a>Fecha de caducidad</a>

									</div>
                    			</th>
                    			<th>
									<div class="fechaprecio">
										<a>Precio en pesos</a>
									</div>
       	            			</th>
       	            			<th>
       	            				Acciones
       	            			</th>
                			</tr>
            			</thead>
	        			<tbody>
						<?php
								
								
								
							while ($row=mysqli_fetch_array($result)){?>
	            			<tr>
	                			<td>
									<a href="producto.php?idProducto=<?php echo $row['idProducto']?>">
										<img class="imagenproductos" src="mostrarImagen.php?idProducto=<?php echo $row['idProducto']?>">
									</a>
	                			</td>
	                			<td>
	                    			<?php echo $row['nombre']?>
	                			</td>
	                			<td>
	                    			<?php echo $row['categoria']?>
	                			</td>
	                			<td>
	                    			<?php echo $row['caducidad']?>
	                			</td>
	                			<td>
	                    			<?php echo $row['precio']?>
	                			</td>
	                			<td>
									<a  class="agregareditar" href="editarproducto.php?idProducto=<?php echo $row['idProducto']?>">Editar</a> 
									<a  onclick="return confirm('Seguro que desea eliminar el producto?')" class="agregareditar" href= "borrarproducto.php?idProducto=<?php echo $row['idProducto']?>">Borrar</a>
	                			</td>
	                			
	            			</tr>
							<?php } 
							mysqli_free_result($result);
							mysqli_close($conex);
						?>
	            			
	        			</tbody>
	    			</table>
	    		</div>			
		</section>
			<div >
				<a  class="submit" href="vende.php">AGREGAR PRODUCTO</a> 
			</div>
		</article>
		<?php 
			include('footer.php');
		?>	
	</div>
</body>
</html>
