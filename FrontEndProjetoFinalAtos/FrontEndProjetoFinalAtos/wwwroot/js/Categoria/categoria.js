function atualizarCategoria(id, nome, status) {

    var inputId = document.getElementById("inputId");
    var inputNome = document.getElementById("inputNome");
    var inputStatus = document.getElementById("inputStatus");
    var tituloid = document.getElementById("titulo-id");
    
    inputId.value = id;
    inputNome.value = nome;
    inputStatus.value = status;
    tituloid.innerHTML = id;

    
}
