# Use a imagem do SDK do .NET para desenvolvimento
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev

# Receba variáveis de ambiente para criar o usuário
ARG user=dotnetuser
ARG uid=1000

# Criação do usuário com permissões personalizadas
RUN useradd -G www-data,root -u $uid -d /home/$user $user && \
    mkdir -p /home/$user && \
    chown -R $user:$user /home/$user

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos do host para o contêiner
COPY ./src /app

# Ajuste permissões para o usuário criado
RUN chown -R $user:$user /app

# Defina o usuário para os comandos subsequentes
USER $user

# Restaure as dependências
RUN dotnet restore

# Exponha a porta da aplicação
EXPOSE 5000

# Use o comando `dotnet run` para rodar no modo desenvolvimento
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]