# Instruções de Execução da Predição

## 📋 Requisitos
- .NET 8 SDK
- Python 3.13.2

## 📌 Clonando o Repositório
1. Para obter o código-fonte, primeiro clone o repositório:
    ```bash
    git clone https://github.com/RodriguesMarllon/dev-backend-test.git
    cd dev-backend-test
    ```

## 🚀 Executando a API C#
1. Navegue até a pasta `api-csharp`:
    ```bash
    cd api-csharp
    ```

2. Instale as dependências:
    ```bash
    dotnet restore
    ```

3. Execute a API:
    ```bash
    dotnet run
    ```

4. A API estará disponível em https://localhost:7184/predict/

## 🐍 Executando a API Python
1. Navegue até a pasta `api-python`:
    ```bash
    cd api-python
    ```

2. Crie um ambiente virtual e instale as dependências:
    ```bash
    python -m venv venv
    venv\Scripts\activate
    pip install -r requirements.txt
    ```

3. Execute a API:
    ```bash
    uvicorn main:app --host 127.0.0.1 --port 8000 --reload
    ```

4. A API estará disponível em http://127.0.0.1:8000/predict/

## 🔗 Testando a Integração
1. Após rodar ambas as APIs, faça um teste com o Postman ou `curl`:
    ```bash
    curl -X POST "http://localhost:7184/predict/2.5/3.1/4.7" -H "accept: application/json"
    ```

2. Se tudo estiver certo, a resposta será algo como:
    ```json
    {
        "prediction": 10.3
    }
    ```
