FROM microsoft/dotnet:1.1-runtime
ARG source
WORKDIR /app
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Convertor_01.dll"]
