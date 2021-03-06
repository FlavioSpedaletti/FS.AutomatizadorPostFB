﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebBot
{
    public class Robo
    {
        public void Execute()
        {
            #region Configurações
            ChromeOptions options = new ChromeOptions();
            ChromeDriver driver;
            WebDriverWait wait;
            options.AddArguments("--start-maximized");
            options.AddArguments("disable-infobars");
            driver = new ChromeDriver(Environment.CurrentDirectory, options, TimeSpan.FromMinutes(5)); //global timeout
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); //explicit wait -> Equivalent as Thread.Sleep(20000), but these code will wait only as long as required

            var user = "flavio.hfs@gmail.com";
            var pass = "xxxx";
            var postUrl = "https://www.facebook.com/PequenosDEVS/posts/2765144423808253";
            var message = "";

            string[] gruposTecEdu =
            {
                "Aprendizagem Criativa",
                "Arduino e Scratch",
                "BLOG DA UKTECH",
                //"CET&D- Ciência,Educação,Tecnologia e Didática",
                "Cidadãos Pela Educação, Ciência, Tecnologia e Inovação",
                "Ciência, Tecnologia e Inclusão na Educação",
                "Code Club Brasil",
                "Computação na Escola",
                "Comunidade Scratch Brasil - Imagine, Programe, Compartilhe!",
                "Crianças&Tecnologia",
                "Cultura MAKER na Educação Básica",
                "Design instrucional e tecnologias educacionais",
                "Educação,Tecnologia e Trabalho",
                "Educação e Tecnologias",
                "Educação Maker",
                "Educação Tecnologias e Inovação",
                "Edukidsdigital - Crianças e Tecnologia",
                "Gamificação da Pedagogia",
                "Gamificação na educação",
                "Grupo de Estudos sobre TIC e Educação Matemática",
                //"Instituto Federal de Educação, Ciência e Tecnologia de Pernambuco (IFPE)",
                "Makers | Juntos fazemos mais",
                "Metodologias Ativas",
                "MÍDIAS E TECNOLOGIAS NA EDUCAÇÃO",
                "Movimento Maker",
                "Neurociência, Educação e suas Tecnologias",
                "Parallax -Educação & Tecnologia",
                "Pensamento Computacional Brasil",
                "Pensando em Códigos",
                "Professores Usando Tecnologias Educacionais na Sala De Aula",
                "Recursos Educacionais Abertos",
                "REDES de APRENDIZAGEM: Educação e Tecnologia",
                "Robótica Livre",
                "Scratch",
                "Scratch e Aprendizagem Criativa",
                "SENATED - Seminário Nacional de Tecnologias na Educação",
                "Tecnologia da Informação e Comunicação - TIC",
                "Tecnologia na Educação",
                "Tecnologia para Educação - Idéias, debates e sugestões.",
                "Tecnologias em Educação",
                "TECNOLOGIAS EM EDUCAÇÃO CCEAD PUC-RIO",
                "Tecnologias na Educação",
                "Tecnologias na Educação - Ensinando e Aprendendo com as TIC",
                "Tecnologias & Educação",
                "TIC Educação",
                "TIC na Educação Básica",
                "TIC Tecnologia de Informação e Comunicação",
                "TICS na Educação"
            };

            string[] gruposProfessores =
            {
                "Grupo Professores da Educação Infantil e Ensino Fundamental I Coruja Sabida",
                "Ideias para Professores de  Educação Infantil e Ensino Fundamental",
                "PROFESSORES ALFABETIZADORES",
                "Professores compartilhando saberes",
                "Professores da Educação Infantil",
                "Professores da Educação Infantil e Fundamental",
                "Professores da Educação Infantil e Fundamental I",
                "PROFESSORES DA PREFEITURA DE SÃO PAULO",
                "Professores do Brasil",
                "professores do ensino fundamental",
                "Professores do Estado de São Paulo",
                "Professores do Estado de S.P.",
                "Professores do Fundamental I - 1º ao 5º ano.",
                "Professores Educação Infantil e Ensino Fundamental",
                "Professores Estado São Paulo"
                //"Trocando experiências entre professores 🎓" //https://unicode.org/emoji/charts/full-emoji-list.html
            };

            #endregion

            driver.Navigate().GoToUrl("https://www.facebook.com");

            var txtEmail = driver.FindElementById("email");
            txtEmail.SendKeys(user);

            var txtPass = driver.FindElementById("pass");
            txtPass.Click();
            //txtPass.SendKeys(pass);
            //txtPass.Submit();

            Console.ReadKey();

            var sucesso = new List<string>();
            var erro = new List<string>();

            var todosGrupos = gruposTecEdu.Union(gruposProfessores);
            foreach (string grupo in todosGrupos)
            {
                try
                {
                    driver.Navigate().GoToUrl(postUrl);

                    //Trocar perfil
                    //var img = "https://scontent.fcgh9-1.fna.fbcdn.net/v/t1.0-1/p32x32/44057206_2215151852140849_6414425517889421312_n.png?_nc_cat=106&_nc_ht=scontent.fcgh9-1.fna&oh=38efbdf8e2c27fff30002bf5581d19a6&oe=5D5CB378";
                    //var ahrefTrocarPerfil = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"img[src='" +  img + "']\").parentElement.parentElement.parentElement"));
                    //var ahrefTrocarPerfil = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('span.accessible_elem').parentNode.firstElementChild.firstElementChild.firstElementChild"));
                    var ahrefTrocarPerfil = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('button[aria-label=\"Seletor de voz\"')"));
                    ahrefTrocarPerfil.Click();
                    Thread.Sleep(2000);
                    //var divPerfilFlavio = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('div[data-tooltip-content=\"Flavio Spedaletti\"').parentElement.parentElement.parentElement.parentElement"));
                    var divPerfilFlavio = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//span[text()='Flavio Spedaletti']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.parentElement.parentElement.parentElement.parentElement"));
                    divPerfilFlavio.Click();
                    Thread.Sleep(2000);

                    //Botão compartilhar
                    //var ahrefFirstShare = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//a[contains(text(), 'Compartilhar')]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue"));
                    var ahrefFirstShare = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//span[text()='Compartilhar']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.parentElement"));
                    ahrefFirstShare.Click();

                    //Botão compartilhar no grupo
                    var btnCompatilharEmGrupo = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//span[contains(text(), 'Compartilhar em um grupo')]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue"));
                    btnCompatilharEmGrupo.Click();

                    //Caixa de texto para digitar nome do grupo
                    //var txtGroupName = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"input[name='audience_group']\")"));
                    var txtGroupName = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector('input[placeholder=\"Procurar grupos\"')"));
                    txtGroupName.SendKeys(grupo);
                    //Método 1, que nem sempre funciona porque a busca do Facebook não é por termos exatos
                    //txtGroupName.SendKeys(Keys.Down);
                    //txtGroupName.SendKeys(Keys.Return);

                    Thread.Sleep(1000);

                    //Método 2, que sempre procura pelo item da lista que contenha o texto exato
                    ////var itemGroupList = wait.Until<IWebElement>(d => ((IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//ul/li//span[contains(text(), '" + grupo + "')]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue")));
                    //var itemGroupList = wait.Until<IWebElement>(d => ((IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//ul/li//span[text()='" + grupo + "']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue")));
                    ////assim não estava clicando em alguns casos, dava o erro "Element is not clickable at point (X, Y). Other element would receive the click: ..."
                    ////itemGroupList.Click();
                    //Actions actions = new Actions(driver);
                    //actions.MoveToElement(itemGroupList).Click().Perform();
                    var itemGroupList = wait.Until<IWebElement>(d => ((IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"div[aria-label='Compartilhar']\")")));
                    itemGroupList.Click();

                    ////não encontrou o do grupo pelo nome
                    //if (txtGroupName.GetAttribute("value") != grupo)
                    //    throw new Exception("Não encontrou o do grupo pelo nome");

                    ////Caixa de texto para escrever mensagem de compartilhamento (opcional)
                    //if (!string.IsNullOrEmpty(message))
                    //{
                    //    var txtMsg = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"div[aria-autocomplete='list']\")");
                    //    txtMsg.Click();
                    //    txtMsg.SendKeys(message);
                    //}

                    ////Incluir publicação original
                    //var divIncluirPublicacaoOriginal = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//div[text()='Incluir publicação original']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue"));
                    //var lblIncluirPublicacaoOriginal = divIncluirPublicacaoOriginal.FindElement(By.TagName("label"));
                    //lblIncluirPublicacaoOriginal.Click();

                    ////Botão Post
                    //var btnPost = wait.Until<IWebElement>(d => (IWebElement)((IJavaScriptExecutor)driver).
                    //                    ExecuteScript("return document.querySelector(\"div[data-tooltip-content='People who can see posts in the group'] + div > button:nth-child(2)\") ||" +
                    //                                         "document.querySelector(\"div[data-tooltip-content='Pessoas que podem ver publicações no grupo'] + div > button:nth-child(2)\")"));
                    //btnPost.Click();

                    ////AQUI PODE TER UMA VERIFICAÇÃO DE SEGURANÇA (RECAPTCHA)
                    //var temCaptcha = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById('captca-recaptcha') !== undefined && document.getElementById('captca-recaptcha') !== null");
                    //if (temCaptcha)
                    //{
                    //    //var iFrameCaptcha = driver.FindElement(By.Id("captca-recaptcha"));
                    //    //driver.SwitchTo().Frame(iFrameCaptcha);
                    //    //var outroIFrame = driver.FindElement(By.TagName("iframe"));
                    //    //driver.SwitchTo().Frame(outroIFrame);
                    //    //var captcha = driver.FindElement(By.ClassName("recaptcha-checkbox-checkmark"));
                    //    //captcha.Click();
                    //    erro.Add(grupo + " - Captcha detected!!");
                    //    Thread.Sleep(10000);
                    //    continue;
                    //}

                    sucesso.Add(grupo);
                    Thread.Sleep(4000);
                }
                catch(Exception ex)
                {
                    erro.Add(grupo + " - " + ex.Message);
                }
            }

            if (sucesso.Count > 0)
            {
                Console.WriteLine("\n\n****************** POSTADOS COM SUCESSO ******************\n");
                Console.Write(string.Join("\n", sucesso));
            }
            if (erro.Count > 0)
            {
                Console.WriteLine("\n\n\n******************** POSTADOS COM ERRO *******************\n");
                Console.Write(string.Join("\n", erro));
            }

            Console.ReadKey();
        }
    }
}
