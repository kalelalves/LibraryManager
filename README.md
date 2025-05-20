# Library Manager

Sistema de gerenciamento de biblioteca desenvolvido seguindo os princípios da Clean Architecture e Clean Code.

## 🏗️ Arquitetura

O projeto segue os princípios da Clean Architecture, dividido em camadas:

- **Core**: Contém as entidades e interfaces do domínio
- **Application**: Implementa os casos de uso e regras de negócio
- **Infrastructure**: Implementa a persistência e serviços externos
- **API**: Camada de apresentação com endpoints REST

### Estrutura do Projeto

```
LibraryManager/
├── LibraryManager.Core/           # Entidades e interfaces
├── LibraryManager.Application/    # Casos de uso e regras de negócio
├── LibraryManager.Infrastructure/ # Implementações de persistência
├── LibraryManager.API/           # API REST
└── LibraryManager.Tests/         # Testes unitários
```

## 🚀 Tecnologias

- .NET 7.0
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- FluentValidation
- xUnit
- Moq

## ✨ Funcionalidades

- Gerenciamento de livros
- Categorização de livros
- Sistema de empréstimos
- Cache para consultas frequentes
- Validações automáticas
- Documentação automática com Swagger
- Tratamento global de exceções
- Logging

## 🛠️ Configuração

1. Clone o repositório
```bash
git clone https://github.com/seu-usuario/LibraryManager.git
```

2. Configure a string de conexão no `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu-servidor;Database=LibraryManager;Trusted_Connection=True;"
  }
}
```

3. Execute as migrações do Entity Framework
```bash
dotnet ef database update
```

4. Execute o projeto
```bash
dotnet run --project LibraryManager.API
```

5. Acesse a documentação Swagger em:
```
https://localhost:5001/swagger
```

## 🧪 Testes

Execute os testes unitários com:
```bash
dotnet test
```

## 📚 Documentação

A documentação da API está disponível através do Swagger UI, que inclui:
- Descrição dos endpoints
- Modelos de requisição/resposta
- Exemplos de uso
- Autenticação (quando aplicável)

## 🔄 Fluxo de Dados

1. **Requisição HTTP** → API Controller
2. **Controller** → Use Case
3. **Use Case** → Repository (via Unit of Work)
4. **Repository** → Database/Cache
5. **Resposta** → Cliente

## 🛡️ Segurança

- Validação de dados com FluentValidation
- Tratamento global de exceções
- Soft Delete para preservação de dados
- Cache para otimização de performance

## 🤝 Contribuindo

1. Faça um Fork do projeto
2. Crie uma Branch para sua Feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE.txt) para mais detalhes.

## 👥 Autores

- Seu Nome - [seu-email@exemplo.com](mailto:seu-email@exemplo.com)

## 🙏 Agradecimentos

- Clean Architecture por Robert C. Martin
- Entity Framework Core
- NextWave 