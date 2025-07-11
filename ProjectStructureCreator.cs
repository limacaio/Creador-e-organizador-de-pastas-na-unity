using UnityEditor;
using UnityEngine;
using System.IO;

public class ProjectStructureCreator : EditorWindow
{
    [MenuItem("Tools/Setup/Create Project Folder Structure")]
    public static void CreateProjectFolders()
    {
        (string path, string description)[] folders = new (string, string)[]
        {
            ("Assets/Art", "Arte em geral: animações, materiais, modelos, sprites, texturas"),
            ("Assets/Art/Animations", "Animações do projeto"),
            ("Assets/Art/Materials", "Materiais utilizados no projeto"),
            ("Assets/Art/Models", "Modelos 3D em geral"),
            ("Assets/Art/Models/Characters", "Modelos de personagens"),
            ("Assets/Art/Models/Monsters", "Modelos de monstros"),
            ("Assets/Art/Models/Environment", "Modelos de ambiente"),
            ("Assets/Art/Sprites", "Sprites para UI e jogos 2D"),
            ("Assets/Art/Textures", "Texturas em geral"),

            ("Assets/Audio", "Áudios em geral"),
            ("Assets/Audio/Music", "Músicas de fundo"),
            ("Assets/Audio/SFX", "Efeitos sonoros"),

            ("Assets/Prefabs", "Prefabs do projeto"),
            ("Assets/Prefabs/Environment", "Prefabs de elementos do ambiente"),
            ("Assets/Prefabs/Enemies", "Prefabs de inimigos"),
            ("Assets/Prefabs/Player", "Prefabs do jogador"),
            ("Assets/Prefabs/UI", "Prefabs de elementos de UI"),

            ("Assets/Scenes", "Cenas do projeto"),

            ("Assets/Scripts", "Scripts gerais"),
            ("Assets/Scripts/Core", "Scripts centrais como GameManager e Helpers"),
            ("Assets/Scripts/Player", "Scripts relacionados ao player"),
            ("Assets/Scripts/Enemies", "Scripts de inimigos"),
            ("Assets/Scripts/UI", "Scripts de interface"),
            ("Assets/Scripts/Systems", "Sistemas gerais: inventário, save, etc."),

            ("Assets/UI", "Assets visuais de UI"),
            ("Assets/UI/Fonts", "Fontes utilizadas na UI"),
            ("Assets/UI/Images", "Imagens e ícones de UI"),
            ("Assets/UI/Prefabs", "Prefabs de UI"),

            ("Assets/Plugins", "Plugins e dependências externas"),
            ("Assets/Resources", "Assets carregados via Resources.Load"),
            ("Assets/Editor", "Scripts de extensões e ferramentas de editor"),

            ("Assets/ThirdParty", "Pacotes de terceiros"),
            ("Assets/ThirdParty/Environments", "Pacotes de ambientes"),
            ("Assets/ThirdParty/Characters", "Pacotes de personagens"),
            ("Assets/ThirdParty/Monsters", "Pacotes de monstros")
        };

        foreach (var (folder, description) in folders)
        {
            if (!AssetDatabase.IsValidFolder(folder))
            {
                Directory.CreateDirectory(folder);
                Debug.Log($"✅ Created folder: {folder} // {description}");
            }
            else
            {
                Debug.Log($"⚠️ Folder already exists: {folder} // {description}");
            }
        }

        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Estrutura Criada", "A estrutura de pastas foi criada/atualizada com sucesso.\nApenas pastas que não existiam foram criadas.", "OK");
    }
}
