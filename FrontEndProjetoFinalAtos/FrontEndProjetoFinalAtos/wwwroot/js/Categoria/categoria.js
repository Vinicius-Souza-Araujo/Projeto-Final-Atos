function atualizarCategoria(id, nome, status) {

    var inputId = document.getElementById("inputId");
    var inputNome = document.getElementById("inputNome");
    var inputStatus = document.getElementById("selectStatus");
    
    inputId.value = id;
    inputNome.value = nome;
   
    for (var i = 0; i < inputStatus.options.length; i++) {
        var option = inputStatus.options[i];

        if (option.value.toLowerCase() === status.toString().toLowerCase()) {
            inputStatus.selectedIndex = i;
            break;
        }
    }
   
    
}
