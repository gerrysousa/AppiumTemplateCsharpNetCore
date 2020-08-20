# AppiumTemplateCsharpNetCore


Configure o Appium

Introdução
- Etapa 1: Instale o Java Development Kit 
  - (JDK)[JDK Download](https://www.oracle.com/java/technologies/javase-downloads.html)
- Etapa 2: Configurar o caminho da variável de ambiente Java 
  - (% JAVA_HOME% \ bin ou C: Arquivos de programas \ Java \ jdk1.8.0_45 \ bin)
  -Para testar se a configuração está correta execute o seguinte comando no CMD "java -version"

- Etapa 3: Instale o Android SDK / ADB no Windows 
  - [Android Studio- SDK Download](https://developer.android.com/studio#Other)

- Etapa 4: Instalar pacotes do Android SDK

- Etapa 5: Configurar a variável de ambiente Android
  - Varialvel de Sistema : "ANDROID_HOME" = "C:\Program Files (x86)\Android\android-sdk"
  - Path: %ANDROID_HOME%\platform-tools
  - Path: %ANDROID_HOME%\tools
  - Path: %ANDROID_HOME%\tools\bin
  
- Etapa 6: Baixe e instale NodeJs 
  - [Download Node JS](https://nodejs.org/en/download/)

- Etapa 7: Instale o Microsoft .net Core
  - [Dot Net Core 3.1- Download](https://dotnet.microsoft.com/download/dotnet-core/3.1)

- Etapa 8: Baixe e instale o Appium Desktop Client
  - [Appium v1.18.0 - Download](https://github.com/appium/appium-desktop/releases/tag/v1.18.0-1)
  - [Todas versões do Appium - Download](https://github.com/appium/appium-desktop/tags)
  
- Etapa 9: Habilite as opções do modo de desenvolvedor no telefone ou tablet Android

- Etapa 10: Instale Visual Studio 2019 e configure um projeto
  - [Visual Studio 2019 - Download](https://visualstudio.microsoft.com/pt-br/downloads/)

- Etapa 11: Abrir o projeto no Visual Studio e compilar o codigo para iniciar o Download das dependências do projeto

- Etapa 12: Primeiro teste Appium para iniciar o aplicativo
  - Executar o executavel do Appium
  - Clicar no Botão "Start Server v1.18.0" no program do Appium
  - Clicar no Botão "Start Inspector Session" (simbolo de uma Lupa)
  - Colocar todas as capacidades informadas abaixo
    - "platformName": "android",
    - "deviceName": "Teste",
    - "platform": "android",
    - "app": "C:\caminho\para\o\App\app-debug.apk",
    - "AutomationName": "UiAutomator2",
    - "udid": "emulator-5554"
  - Clicar no botão "Start Session". O Appium deverá iniciar o aplicativo "app-debug.apk" no emulador/celular informado no "UDID"
- Observação:  O emulador deve estar em execução, ou o celular deve estar conectado ao computador que o Appium está rodando.



Configuração minima para o servidor Appium iniciar uma App no Device:
```
{
  "platformName": "android",
  "deviceName": "Teste",
  "platform": "android",
  "app": "C:\caminho\para\o\App\app-debug.apk",
  "AutomationName": "UiAutomator2",
  "udid": "emulator-5554"
}
```
Comandos Uteis:
- Listar dispositivos Adb, para pegar o UDID dos dispositivos:
```
$adb devices
Resultado: emulator-5554   device
```
- Listar Emuladores, para pegar o nome dos emuladores:
```
$emulator -list-avds
Resultado: Pixel_3a_API_28
```
- Instalar Appium Service no Node.
```$npm install -g appium```

@gerrysousa
