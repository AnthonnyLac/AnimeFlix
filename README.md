# AnimeFlix

## Requisitos

Para utilizar este projeto, você precisará ter os seguintes itens instalados em seu ambiente de desenvolvimento:

- **Visual Studio 2022** (a versão mais recente).
- **.NET Core SDK 6.0** (Certifique-se de ter a mesma versão que está especificada no arquivo global.json).
  - Você pode baixar a versão mais recente do SDK e outras ferramentas em [dot.net/core](https://dot.net/core).
- Para instalar a ferramenta **dotnet-ef**, execute o seguinte comando no PowerShell:

```bash
dotnet tool install --global dotnet-ef
```

## Como criar o banco de dados

Siga estas etapas para criar o banco de dados necessário para o projeto:

1. Abra seu terminal no diretório **\src\AnimeFlix.Infra.Data**.
2. Execute o seguinte comando no terminal:

```bash
dotnet ef database update --startup-project ..\AnimeFlix.WebApi
```

## Executando o projeto

Para iniciar o projeto AnimeFlix, siga estas etapas:

- Abra seu terminal no diretório \src\AnimeFlix.WebApi\AnimeFlix.WebApi.
- Execute o seguinte comando no terminal:

```bash
dotnet run
```

## Vídeos

- [Anthonny](https://youtu.be/0Z3Y5n2XZ3o)
- [William Felipe(Parte 2)](https://youtu.be/wAKsH6FaFjc)
