# Cadastro de Pacientes - Aplicação Web em C#

Este projeto é uma aplicação web em C# para o cadastro, visualização e gerenciamento de informações de pacientes. Ele foi desenvolvido utilizando o framework ASP.NET Core com Razor Pages, permitindo a inserção, edição, pesquisa e exclusão de registros de pacientes. A interface foi construída utilizando o Bootstrap para garantir uma experiência visual agradável e responsiva.

## Funcionalidades

- **Cadastro de Pacientes**: O formulário permite cadastrar pacientes informando a chave do paciente (6 dígitos), nome do médico, data de internação e telefone de contato.
- **Pesquisa de Pacientes**: Permite buscar um paciente específico informando a chave.
- **Edição de Pacientes**: Através de um modal, é possível editar as informações do paciente cadastrado.
- **Exclusão de Pacientes**: Oferece a funcionalidade de excluir um paciente através de um botão de ação.
- **Listagem de Pacientes**: Todos os pacientes cadastrados são exibidos em uma tabela, com as opções de editar ou excluir.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework utilizado para o desenvolvimento da aplicação web.
- **Razor Pages**: Modelo de desenvolvimento baseado em páginas e MVC.
- **Bootstrap 4**: Framework CSS para design responsivo e estilização dos componentes.
- **JavaScript/jQuery**: Utilizado para interação dinâmica com a interface.
- **Modal de Edição**: Utiliza Bootstrap Modal para editar as informações do paciente.

## Como Rodar o Projeto

### Pré-requisitos

- .NET SDK (versão 5.0 ou superior).
- Visual Studio ou Visual Studio Code com o C# extension instalado.

### Passos para Executar

1. Clone este repositório para a sua máquina local:
    ```bash
    git clone https://github.com/SeuUsuario/CadastroPacientes.git
    ```

2. Navegue até o diretório do projeto:
    ```bash
    cd CadastroPacientes
    ```

3. Abra o projeto no Visual Studio ou Visual Studio Code:
    ```bash
    code .
    ```

4. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

5. Execute o projeto:
    ```bash
    dotnet run
    ```

6. Acesse a aplicação pelo navegador no endereço: `http://localhost:5000`

## Estrutura de Arquivos

- **Pages/Cadastro.cshtml**: Página principal de cadastro de pacientes.
- **wwwroot/js/site.js**: Arquivo de JavaScript para interações na interface.
- **wwwroot/css/styles.css**: Estilos adicionais personalizados (caso necessário).
- **Models/CadastroModel.cs**: Classe que representa os dados do paciente.

## Funcionalidade de Edição e Exclusão

As ações de editar e excluir são realizadas por meio de JavaScript, com modais para edição e comunicação assíncrona com o servidor para atualizar ou excluir os registros dos pacientes.

- O modal de edição permite modificar os campos: Nome do Médico, Data de Internação e Telefone de Contato.
- Após a edição ou exclusão, a página será automaticamente atualizada para refletir as alterações.

## Contribuições

Contribuições são bem-vindas! Se você deseja melhorar o projeto, pode abrir uma **pull request** ou sugerir novas funcionalidades.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

Se você tiver qualquer dúvida ou precisar de mais informações, fique à vontade para abrir uma issue ou entrar em contato!
