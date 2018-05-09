<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Categorías</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<body>
	<div id="global">
		<?php
			include('header.php');
	
			if(!session_id()){ //para ver si la sesión está iniciada
				session_start();
			}
			
			include('usuario.php');
			$user= new usuario(); //instancia de una clase
			$user->estaRegistrado();
			
			
			$query="SELECT * FROM categorias_productos";

			$result=mysqli_query($conex,$query) or die ('error');
		?>

		<section>
				<p><strong>Tus categorías:</strong></p>
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
                    				<div id="categoria">
										Categoría
									</div>
                    			</th>
                    			<th>
                    				<div class="fechaprecio">
                    					Acciones
												
									</div>
                    			</th>
                			</tr>
            			</thead>
	        			<tbody>
						<?php
								
							while ($row=mysqli_fetch_array($result)){?>
	            			<tr>
	                			<td>
	                    			<?php echo $row['nombre']?>
	                			</td>
	                			<td>
									<a  class="agregareditar" href="editarcategoria.php?idCategoriaProducto=<?php echo $row['idCategoriaProducto']?>">Editar</a> 
									<a onclick="return confirm('Seguro que desea eliminar el producto?')" class="agregareditar" href= "borrarcategoria.php?idCategoriaProducto=<?php echo $row['idCategoriaProducto']; ?>">Borrar</a>
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
				<a  class="submit" href="categoriaalta.php">AGREGAR CATEGORÍA</a> 
			</div>
		</article>
		<?php 
			include('footer.php');
		?>	
	</div>
</body>
</html>
