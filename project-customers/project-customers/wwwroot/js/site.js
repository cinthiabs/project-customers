function validarCampos() {
    var nome = document.getElementById("nome").value;
    var email = document.getElementById("email").value;
    var telefone = document.getElementById("telefone").value;
    var tipoPessoa = document.getElementById("tipoPessoa").value;
    var cpfCnpj = document.getElementById("cpfCnpj").value;
    var senha = document.getElementById("senha").value;
    var confirmacaoSenha = document.getElementById("confirmacaoSenha").value;

    if (nome.trim() === "" || email.trim() === "" || telefone.trim() === "" || tipoPessoa.trim() === "" || cpfCnpj.trim() === "" || senha.trim() === "" || confirmacaoSenha.trim() === "") {
        alert("Por favor, preencha todos os campos obrigatórios.");
        return false;
    }
    if (senha !== confirmacaoSenha) {
        document.getElementById("senhaHelp").style.display = "block";
        return false;
    }
    enviarDados();
}

function enviarDados() {
    var nome = $('#nome').val();
    var email = $('#email').val();
    var telefone = $('#telefone').val();
    var tipoPessoa = $('#tipoPessoa').val();
    var cpfCnpj = $('#cpfCnpj').val();
    var senha = $('#senha').val();
    var confirmacaoSenha = $('#confirmacaoSenha').val();
    var bloqueado = $('#bloqueado').is(':checked');
    var dataNascimento = $('#dataNascimento').val();
    var genero = $('#genero').val();
    var inscricaoEstadual = $('#inscricaoEstadual').val();


    var clienteData = {
        Nome: nome,
        Email: email,
        Telefone: telefone,
        TipoPessoa: tipoPessoa,
        CpfCnpj: cpfCnpj,
        Senha: senha,
        ConfirmacaoSenha: confirmacaoSenha,
        Bloqueado: bloqueado,
        DataNascimento: dataNascimento,
        Genero: genero,
        InscricaoEstadual: inscricaoEstadual
    };

    $.ajax({
        url: '@Url.Action("Index", "Cliente")',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(clienteData),
        success: function (response) {
            if (response.redirectUrl) {
                alert('Cliente adicionado com sucesso!');
                window.location.href = response.redirectUrl;
            } else {
                alert(response);
            }
        }
            error: function (xhr, status, error) {
            console.log(error);
            alert('Ocorreu um erro ao adicionar o cliente.');
        }
    });
}

function limparFiltros() {
    document.getElementById("nome_razao_social").value = "";
    document.getElementById("email").value = "";
    document.getElementById("telefone").value = "";
    document.getElementById("data_cadastro").value = "";
    document.getElementById("cliente_bloqueado").selectedIndex = "";
}
