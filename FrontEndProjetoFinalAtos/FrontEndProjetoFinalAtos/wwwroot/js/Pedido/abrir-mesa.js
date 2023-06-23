var contador = 0;

function adicionarPessoa() {

    // Obter os valores dos inputs
    var id = document.getElementById('selectProduto').value;
    var produto = document.getElementById('selectProduto').options[document.getElementById('selectProduto').selectedIndex].text;
    var quantidade = document.getElementById('inputQuantidade').value;

    if (quantidade === '') {
        alert('Por favor, informe a quantidade.');
        return;
    }

    // Criar uma nova linha na tabela
    var tabela = document.getElementById('corpoTabela');
    var novaLinha = tabela.insertRow();

    // Inserir células na nova linha
    var celulaId = novaLinha.insertCell();
    var celulaProduto = novaLinha.insertCell();
    var celulaQuantidade = novaLinha.insertCell();
    var celulaExcluir = novaLinha.insertCell();

    // Atribuir os valores dos inputs às células
    celulaId.innerHTML = id;
    celulaProduto.innerHTML = produto;
    celulaQuantidade.innerHTML = quantidade;

    contador++;

    var htmlItensPedidosId = '<td name="ItensPedidos[' + contador + '].FkProduto">' + id + '</td>';
    console.log(htmlItensPedidosId);
    celulaId.innerHTML = htmlItensPedidosId;
    celulaProduto.innerHTML = '<td id="celulaProduto_' + id + '">' + produto + '</td>';
    celulaQuantidade.innerHTML = '<td id="celulaQuantidade_' + id + '">' + quantidade + '</td>';
    
    celulaExcluir.innerHTML = '<button onclick="excluirPessoa(this)"><img src="/img/icone-excluir.svg"></button>';

    // Limpar os inputs após adicionar os dados à tabela
 
    document.getElementById('inputQuantidade').value = '';

    var tabelaItens = document.getElementById('corpoTabela');
    var linhasItens = tabelaItens.getElementsByTagName('tr');
    var temLinhas = linhasItens.length > 0;

    // Habilitar ou desabilitar o botão "Confirmar" com base na presença de linhas na tabela
    var botaoConfirmar = document.getElementById('button-confirmar');
    botaoConfirmar.disabled = !temLinhas;
}

function excluirPessoa(botaoExcluir) {
    // Obter a linha da tabela a ser excluída
    var linha = botaoExcluir.parentNode.parentNode;

    // Remover a linha da tabela
    linha.parentNode.removeChild(linha);

    var tabelaItens = document.getElementById('corpoTabela');
    var linhasItens = tabelaItens.getElementsByTagName('tr');

    var botaoConfirmar = document.getElementById('button-confirmar');
    botaoConfirmar.disabled = linhasItens.length === 0;
}


function enviarDadosParaController() {

    var cliente = document.getElementById('inputCliente').value;
    var mesa = document.getElementById('inputMesa').value;

    
    if (cliente === '' || mesa === '') {
        alert('Por favor, preencha o campo cliente e mesa.');
        return;
    }

    var tabela = document.getElementById('corpoTabela');
    var linhas = tabela.getElementsByTagName('tr');
    var dados = [];


    for (var i = 0; i < linhas.length; i++) {
        var linha = linhas[i];
        var id = linha.cells[0].innerHTML;
        var quantidade = linha.cells[2].innerHTML;

        dados.push({
            FkProduto: id,
            Quantidade: quantidade
        });

    }
    
    $.ajax({
        url: '/Pedido/AdicionarItemPedido', // URL do método na controller
        method: 'POST', 
        data: {
            cliente: cliente,
            mesa: mesa,
            dados: dados
        }, 
        success: function (response) {
            alert('Pedido enviado com sucesso!');
            document.getElementById('inputCliente').value = '';
            document.getElementById('inputMesa').value = '';
            tabela.innerHTML = '';

            var botaoConfirmar = document.getElementById('button-confirmar');
            botaoConfirmar.disabled = true;
            
        },
        error: function (error) {
            alert('Erro ao enviar o pedido!');
            console.log('Erro na requisição AJAX:', error);
        }
    });
}