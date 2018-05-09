<nav>
				<ul class="barramenu">
					<li>
						<a href="index.php">INICIO</a>
					</li>
					<li>
						<a href="tienda.php">TIENDA ONLINE</a>
					</li>
					<?php
						if(isset($_SESSION['id_usuario'])){ ?>  
							<li>
								<a href="tusproductos.php">PRODUCTOS</a>
							</li>
							<li>
								<a href="categorias.php">CATEGORIAS</a>
							</li>
							<li>
								<a href="micuenta.php">MI CUENTA</a>
							</li>
						<?php } else{ ?>
							<li>
								<a href="perfil.php">REGISTRARSE</a>
							</li>
							<li>
								<a href="ingresar.php">INGRESAR</a>
							</li>
						<?php } ?>
				</ul>
</nav>
