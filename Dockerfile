FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AppApi.csproj", "./"]
RUN dotnet restore "./AppApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AppApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AppApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENV ASPNETCORE_EVIROMENT Development

ENTRYPOINT ["dotnet", "AppApi.dll"]
