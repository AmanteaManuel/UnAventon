function runSubmit (form)  {
		if (form.categoria.value ==""){
			alert("Ingrese categoria");
			return false;
		}
		if (form.titulo.value == ""){
			alert("Ingrese título");
			return false;
		}
		if (form.precio.value == ""){
			alert("Ingresar precio");
			return false;
		}
		if (form.fechacaducidad.value == "") {
			alert("Ingresar DD/MM/AAAA");
			return false;
		}
		if (form.descripcion.value == ""){
			alert("Ingrese descripción");
			return false;
		}
		if (form.foto.value == ""){
			alert("Ingrese una foto");
			return false;
		}
		return true;	
}	
	
