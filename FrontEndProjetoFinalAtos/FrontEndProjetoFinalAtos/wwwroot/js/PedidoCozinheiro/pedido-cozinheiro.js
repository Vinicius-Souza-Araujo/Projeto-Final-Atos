setTimeout(function() {
  location.reload();
}, 60000);

function dadosModal(mesa, id) {
    
    document.getElementById('p-modal').textContent = "Mesa " + mesa;

    $.ajax({
        url: '/PedidoCozinheiro/BuscarItensPedidos?id=' + id,
        method: 'GET',
        success: function (response) {
          
            var lista = document.getElementById('lista-dados');
            lista.innerHTML = '';
            response.forEach(function (item) {
                var li = document.createElement('li');
                li.textContent = "Quantidade: " + item.quantidade + " | Produto: " + item.fkProdutoNavigation.nome;
                lista.appendChild(li);
            });

        },
        error: function (error) {
            console.log('Erro na requisição AJAX:', error);
        }
    });

}