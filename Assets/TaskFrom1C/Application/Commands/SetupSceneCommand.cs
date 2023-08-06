using System;
using TaskFrom1C.Camera;
using TaskFrom1C.SceneObjectsStorage;
using TaskFrom1C.UI;

namespace TaskFrom1C.Application.Commands
{
    public class SetupSceneCommand : ICommand
    {
        public event Action OnDone;
        
        private readonly ISceneObjectStorage _sceneObjectStorage;

        private const string CameraViewSource = "CameraView";
        private const string CanvasSource = "GameCanvas";
        
        public SetupSceneCommand(ISceneObjectStorage sceneObjectStorage)
        {
            _sceneObjectStorage = sceneObjectStorage;
        }
        
        public void Execute()
        {
            var cameraView = _sceneObjectStorage.CreateFromResourcesAndAdd<CameraView>(CameraViewSource);
            var gameCanvas = _sceneObjectStorage.CreateFromResourcesAndAdd<GameCanvas>(CanvasSource);

            gameCanvas.Canvas.worldCamera = cameraView.Camera;
        }
    }
}