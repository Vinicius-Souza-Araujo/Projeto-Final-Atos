function atualizarProduto(id, nome, valor, idCategoria, status) {

    var inputId = document.getElementById("inputId");
    var inputNome = document.getElementById("inputNome");
    var inputPreco = document.getElementById("inputPreco");
    var selectCategorias = document.getElementById("selectCategoria");
    var selectStatus = document.getElementById("selectStatus");

    inputId.value = id;
    inputNome.value = nome;
    inputPreco.value = valor;

    for (var i = 0; i < selectCategorias.options.length; i++) {
        var option = selectCategorias.options[i];

        if (option.value === idCategoria) {
            selectCategorias.selectedIndex = i;
            break;
        }
    }

    for (var i = 0; i < selectStatus.options.length; i++) {
        var option = selectStatus.options[i];

        if (option.value.toLowerCase() === status.toString().toLowerCase()) {
            selectStatus.selectedIndex = i;
            break;
        }
    }
}