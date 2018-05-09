
<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/icono.ico"/>
	<title>Reversa | Tienda online</title>
	<link rel="stylesheet" type="text/css" href="css-js/estilo1.css">
</head>
<body>
	<div id="global">
		<?php
			include('header.php');

			$query="SELECT * FROM categorias_productos"; 
			$result=mysqli_query($conex,$query) or die ('error'); 
		
		?>
		<div class="buscador">
			<form id="search_mini_form" action="tienda.php" method="get">
			
					<select id="gender" name="gender" title="Categoría" class="validate-select"/>
						<option value="todos">Seleccione una opcion</option>
						<?php 
							while($row = mysqli_fetch_array($result)){
								$selected = "";
								if ( isset($_GET['gender']) ){
																										
									if( $_GET['gender'] == $row['idCategoriaProducto']){
										$selected = 'selected';	
									}
								}	
								?>
							<option  <?php echo $selected ?> value="<?php echo $row['idCategoriaProducto']?>"><?php echo $row['nombre'] ?></option>
							<?php 
							}
						?>
					</select>
					 
						<input type="text" name="producto"/>
						
					


				<button type="submit" title="Categoría" class="button">Buscar</button>
			</form>

			


		</div>
			
			<section>
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
											$query="SELECT p.idProducto, p.nombre as nombre, c.nombre as categoria, p.caducidad, p.precio FROM  `productos` p INNER JOIN categorias_productos c ON p.idCategoriaProducto = c.idCategoriaProducto where p.caducidad >= '$fecha_actual'";
												
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
											include('paginador2.php');
										?>				
						 
										<a href="tienda.php?orden_fecha=<?php echo $orden_fecha; if( isset($_GET['gender']) ){ ?>&gender=<?php echo $_GET['gender']; }?>">Fecha de caducidad</a>

									</div>
                    			</th>
                    			<th>
									<div class="fechaprecio">
										<a href="tienda.php?orden_precio=<?php echo $orden_precio; if(isset($_GET['gender']) ){ ?>&gender=<?php echo $_GET['gender'];} ?>">Precio en pesos</a>
									</div>
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
	            			</tr>
							<?php } 
							mysqli_free_result($result);
							mysqli_close($conex);
						?>
	            			
	        			</tbody>
	    			</table>
	    		</div>			
			</section>

    

            <nav>
   
				<ul id="paginador">
				<?php
			    //UNA VEZ Q MUESTRO LOS DATOS TENGO Q MOSTRAR EL BLOQUE DE PAGINACIÓN SIEMPRE Y CUANDO HAYA MÁS DE UNA PÁGINA
			      
			    if($numproductos != 0)
			    {
			       $nextpage= $page +1;
			       $prevpage= $page -1;
			     
			       ?><ul id="paginador"><?php
			           //SI ES LA PRIMERA PÁGINA DESHABILITO EL BOTON DE PREVIOUS, MUESTRO EL 1 COMO ACTIVO Y MUESTRO EL RESTO DE PÁGINAS
			           if ($page == 1) 
			           {
			            ?>
			              <li>&laquo; Anterior</li>
			              <li>1</li> 
			         <?php
			              for($i= $page+1; $i<= $ultpag ; $i++)
			              {?>
			                <li><a href="tienda.php?page=<?php echo $i;?>"><?php echo $i;?></a></li>
			        <?php }
			           
			           //Y SI LA ULTIMA PÁGINA ES MAYOR QUE LA ACTUAL MUESTRO EL BOTON NEXT O LO DESHABILITO
			            if($ultpag >$page )
			            {?>      
			                <li class="next"><a href="tienda.php?page=<?php echo $nextpage;?>" >Siguiente &raquo;</a></li><?php
			            }
			            else
			            {?>
			                <li class="next">Siguiente &raquo;</li>
			        <?php
			            }
			        } 
			        else
			        {
			     
			            //EN CAMBIO SI NO ESTAMOS EN LA PÁGINA UNO HABILITO EL BOTON DE PREVIUS Y MUESTRO LAS DEMÁS
			        ?>
			            <li><a href="tienda.php?page=<?php echo $prevpage;?>">&laquo; Anterior</a></li><?php
			             for($i= 1; $i<= $ultpag ; $i++)
			             {
			                           //COMPRUEBO SI ES LA PÁGINA ACTIVA O NO
			                if($page == $i)
			                {
			            ?>       <li><?php echo $i;?></li><?php
			                }
			                else
			                {
			            ?>       <li><a href="tienda.php?page=<?php echo $i;?>" ><?php echo $i;?></a></li><?php
			                }
			            }
			             //Y SI NO ES LA ÚLTIMA PÁGINA ACTIVO EL BOTON NEXT     
			            if($ultpag >$page )
			            {   ?>   
			                <li class="next"><a href="tienda.php?page=<?php echo $nextpage;?>">Siguiente &raquo;</a></li><?php
			            }
			            
	
			        }     
    				?></ul></div><?php
    				} 
					?>

   				</ul>
			</nav>
			
		</article>
		
	</div>
</body>
</html>
