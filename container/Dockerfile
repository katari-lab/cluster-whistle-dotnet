FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as builder
WORKDIR /build/
COPY ./ .
RUN ls -l
RUN apt-get -y update
RUN apt-get -y install dnsutils
RUN apt-get -y install vim
RUN apt-get install -y procps

RUN dotnet build cluster-whistle-dotnet.sln -v:q
RUN dotnet publish src/whistle.api -c Release -v:q
RUN ls src/whistle.api/bin/Release/netcoreapp3.1

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=builder /build/src/whistle.api/bin/Release/netcoreapp3.1 . 
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "whistle.api.dll"] 






