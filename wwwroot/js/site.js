function deletarPaciente(button) {
    const chave = parseInt(button.getAttribute('data-chaves'));
    const row = button.closest('tr');

    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    fetch('/Cadastro?handler=Delete', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        },
        body: JSON.stringify({ chave: chave })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro na resposta do servidor: ' + response.status);
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                row.remove();
                alert('Paciente deletado com sucesso.');
            } else {
                alert('Erro ao deletar paciente: ' + (data.message || 'Erro desconhecido.'));
            }
        })
        .catch(error => {
            console.error('Erro:', error);
            alert(`Erro ao deletar paciente: ${error.message}`);
        });
}




function editarPaciente(button) {
    const chave = parseInt(button.getAttribute('data-chaves'));
    const row = button.closest('tr');

    document.getElementById('editarChave').value = chave;
    document.getElementById('editarNomeMedico').value = row.cells[1].innerText;
    document.getElementById('editarDataInternacao').value = row.cells[2].innerText;
    document.getElementById('editarTelefoneContato').value = row.cells[3].innerText;

    $('#editarModal').modal('show');
}




document.getElementById('formEditar').onsubmit = function (event) {
    event.preventDefault();

    const pacienteEditado = {
        Chave: document.getElementById('editarChave').value,
        NomeDoMedico: document.getElementById('editarNomeMedico').value,
        DataInternacao: document.getElementById('editarDataInternacao').value,
        TelefoneContato: document.getElementById('editarTelefoneContato').value
    };

    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    fetch('/Cadastro?handler=Editar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        },
        body: JSON.stringify(pacienteEditado)
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                alert('Paciente editado com sucesso.');
                location.reload();
            } else {
                alert('Erro ao editar paciente: ' + data.message);
            }
        })
        .catch(error => console.error('Erro:', error));


    
};



function fecharModal() {
    $('#editarModal').modal('hide'); 
}


document.querySelector('.close.btn-danger').addEventListener('click', fecharModal);




function buscarPaciente() {
    const chave = document.getElementById('search').value.trim();
    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

    
    const url = chave === '' ? '/Cadastro?handler=TodosPacientes' : `/Cadastro?handler=Buscar&chave=${chave}`;

    fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro na resposta do servidor: ' + response.status);
            }
            return response.json();
        })
        .then(data => {
            const tbody = document.querySelector('table tbody');
            tbody.innerHTML = ''; 

            if (data.success) {
                const pacientes = chave === '' ? data.pacientes : [data.paciente];

                if (pacientes && pacientes.length > 0) {
                    pacientes.forEach(paciente => {
                        const dataInternacao = new Date(paciente.dataInternacao);
                        const dataFormatada = dataInternacao.toLocaleDateString('pt-BR');

                        const row = `
                    <tr data-chaves='${paciente.chave}'>
                        <td>${paciente.chave}</td>
                        <td>${paciente.nomeDoMedico}</td>
                        <td>${dataFormatada}</td>
                        <td>${paciente.telefoneContato}</td>
                        <td>
                            <button class='btn btn-danger' data-chaves='${paciente.chave}' onclick='deletarPaciente(this)'>Deletar</button>
                            <button class='btn btn-primary' data-chaves='${paciente.chave}' onclick='editarPaciente(this)'>Editar</button>
                        </td>
                    </tr>`;
                        tbody.innerHTML += row;
                    });
                } else {
                    alert('Nenhum paciente encontrado.');
                }
            } else {
                alert('Erro: ' + (data.message || 'Não foi possível buscar os pacientes.'));
            }
        })
        .catch(error => {
            console.error('Erro:', error);
            alert(`Erro ao buscar paciente(s): ${error.message}`);
        });
}