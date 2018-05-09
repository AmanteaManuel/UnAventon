<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Producto</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<body>
	<div id="global">
	<?php
		include('header.php');
	?>

		<article>
			<?php 
				$id=$_GET['idProducto'];
				$query="SELECT p.idProducto, p.nombre as nombre, c.nombre as categoria, p.caducidad, p.publicacion, p.precio, p.descripcion FROM  `productos` p INNER JOIN categorias_productos c ON p.idCategoriaProducto = c.idCategoriaProducto where p.idProducto= $id";
				$result=mysqli_query($conex,$query) or die ('error');
				$row=mysqli_fetch_array($result);
			?>
			<aside>
				<div id="fotoproducto">
					<img  class= "lateral" src="mostrarImagen.php?idProducto=<?php echo $row['idProducto']?>"> 
	            </div>
			</aside>
			<section>
				<div class="productotabla">
						<table> <!--id="tablaproducto"-->
		        			<tbody>

									<tr>
										<td><strong><h1><?php echo $row['nombre']?></h1></strong></td>
									</tr>
									<tr>
										<td>$ <?php echo $row['precio']?></td>
									</tr>
									<tr>
										<td>Categoría: <?php echo $row['categoria']?></td>
									</tr>
									<tr>
										<td>Fecha publicación: <?php echo $row['publicacion']?></td>
									</tr>
									<tr>
										<td>Fecha caducidad: <?php echo $row['caducidad']?></td>
									</tr>
									<tr>
										<td>Descripción: <?php echo $row['descripcion']?></td>
									</tr>
									
					            <?php 
									mysqli_free_result($result); //libera la memoria del resultado 
									mysqli_close($conex);
								?>
 
					            
							</tbody>
		    		</table>
		    	</div>
		    </section>
				
		</article>
		<?php 
			include('footer.php');
		?>
		
		
	</div>
</body>
</html>
