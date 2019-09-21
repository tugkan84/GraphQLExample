FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["GraphQLDeneme/GraphQLDeneme.csproj", "GraphQLDeneme/"]
RUN dotnet restore "GraphQLDeneme/GraphQLDeneme.csproj"
COPY . .
WORKDIR "/src/GraphQLDeneme"
RUN dotnet build "GraphQLDeneme.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GraphQLDeneme.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQLDeneme.dll"]