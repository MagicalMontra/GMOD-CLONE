// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// using Zenject;

// using System.Threading.Tasks;


// namespace Gamespace.Core.Blueprint
// {
//    public class BlueprintController : MonoBehaviour
//    {
//        public static BlueprintController singleton;

//        [Header("Mode")]
//        public GameModeSignal myGetMode;
//        public GameMode myGameMode;

//        [Inject]
//        private SignalBus _signalBus;

//        public TextMeshProUGUI modeText = null;


//        [Header("Panel")]
//        public GameObject blueprintGroup;
//        public GameObject selectedRoomPanel;
//        public GameObject unSelectedRoomPanel;
//        public GameObject buildRoomPanel;


//        [Header("Room")]
//        public GameObject roomButtonPrefab;
//        public RectTransform roomContent;
//        public RoomModelScriptableObject roomModelInfo;


//        public SwitchObjectMode switchObjectMode = null;
//        [SerializeField] private GameObject blueprintCameraOverlay = null;
//        [SerializeField] private Transform blueprintCameraTrans = null;

//        private List<RoomBase> rooms = new List<RoomBase>();



//        private void Awake()
//        {
//            singleton = this;
//        }

//        // Start is called before the first frame update
//        void Start()
//        {
//            Init();
//        }


//        public void Init()
//        {
//            blueprintGroup.SetActive(false);
//            blueprintCameraOverlay.SetActive(false);
//            modeText.text = "";
//            for (int i = 0; i < rooms.Count; i++)
//            {
//                //rooms[i].SetGhostShader(0);
//            }
//            switchObjectMode.SwitchCamera(false);

//            buildRoomPanel.SetActive(false);

//            _signalBus.Subscribe<GameModeSignal>(GetMode);
//            SetUpRoomButton();
//        }
//        // Update is called once per frame
//        void Update()
//        {
//            if (myGameMode == GameMode.BluePrint)
//            {

//                if (Input.GetKeyUp(KeyCode.T))
//                {
//                    bluePrintCamera.TeleportPlayerToSelectedRoom();
//                }

//                if (!buildRoomPanel.activeInHierarchy)
//                {
//                    if (Input.GetKeyUp(KeyCode.G))
//                    {
//                        buildRoomPanel.SetActive(true);
//                    }
//                }
//                else
//                {
//                    if (Input.GetKeyUp(KeyCode.Escape))
//                    {
//                        buildRoomPanel.SetActive(false);
//                    }
//                }
//            }
//        }

//        private void SetUpRoomButton()
//        {
//            for (int i = 0; i < roomModelInfo.roomDetails.Length; i++)
//            {
//                GameObject o = Instantiate(roomButtonPrefab);
//                o.transform.SetParent(roomContent);
//                o.GetComponent<RoomButton>().SetUp(i, roomModelInfo.roomDetails[i].roomIcon);
//            }
//        }

//        public void AddRoom(RoomBase r)
//        {
//            rooms.Add(r);
//        }

//        public void RemoveRoom(RoomBase r)
//        {
//            rooms.Remove(r);
//        }


//        public List<GameObject> GetRoom()
//        {
//            List<GameObject> roomObject = new List<GameObject>();
//            for (int i = 0; i < rooms.Count; i++)
//            {
//                roomObject.Add(rooms[i].gameObject);
//            }
//            return roomObject;
//        }

//        void GetMode(GameModeSignal signal)
//        {
//            myGameMode = signal.GameMode;


//            if (signal.GameMode == GameMode.BluePrint)
//            {
//                blueprintGroup.SetActive(true);
//                floorSilder.gameObject.SetActive(true);
//                blueprintGroup.SetActive(true);
//                blueprintCameraOverlay.SetActive(true);
//                modeText.text = "BLUEPRINT MODE";
//                SetRoomsMaterial(1);
//                switchObjectMode.SwitchCamera(true);

//                _signalBus.Fire(new PlayerLockSignal("", "BluePrintEditor"));
//                return;
//            }

//            blueprintGroup.SetActive(false);
//            blueprintCameraTrans.GetComponent<BluePrintCamera>().OnDeselectRoom();
//            _signalBus.Fire(new PlayerLockSignal("", "BluePrintEditor"));
//            blueprintGroup.SetActive(false);
//            blueprintCameraOverlay.SetActive(false);
//            modeText.text = "";

//            SetRoomsMaterial(0);

//            switchObjectMode.SwitchCamera(false);
//            buildRoomPanel.SetActive(false);
//            //ObjectModeActivator.SetActive(true);


//        }
//        public void SetRoomHint(bool isSelected)
//        {
//            unSelectedRoomPanel.SetActive(!isSelected);
//            selectedRoomPanel.SetActive(isSelected);
//        }
//        public async void BuildRoom(int index = 0)
//        {
//            Vector3 v = new Vector3(0, 5000, 0);
//            GameObject roomTemp = Instantiate(roomModelInfo.roomDetails[index].roomPrefab, v, roomModelInfo.roomDetails[index].roomPrefab.transform.rotation) as GameObject;
//            buildRoomPanel.SetActive(false);
//            await Task.Delay(100);
//            bluePrintCamera.targetRoom = roomTemp.GetComponent<RoomBase>();
//            bluePrintCamera.targetRoom.OnSelected();
//            SetRoomHint(true);

//        }

     
//        public void SetRoomsMaterial(int indx)
//        {
//            if (rooms.Count == 0)
//            {
//                return;
//            }
//            for (int i = 0; i < rooms.Count; i++)
//            {
//                rooms[i].SetGhostShader(indx);
//            }
//        }
//        public void EnableRoom(bool isEnable)
//        {
//            for (int i = 0; i < rooms.Count; i++)
//            {
//                rooms[i].EnableRoomCollider(isEnable);
//            }
//        }


//    }

// }

