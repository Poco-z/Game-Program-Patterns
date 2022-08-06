/*
* @创建日期: 2022/07 14:44:23
* @创 建 者: xinxin.zhao@igg.com 
* @功能描述: CommandGameCtroller
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Partice
{
    public class CommandGameCtroller:MonoBehaviour
    {
        public Commmand buttonA;
        public Commmand buttonD;
        public Commmand buttonW;
        public Commmand buttonS;

        public MoveObject moveTarget;

        private Stack<Commmand> undoCommonds = new Stack<Commmand>();
        private Stack<Commmand> redoCommonds = new Stack<Commmand>();

        private bool m_IsReplaying;
        private const float REPLAY_STEP_TIME = 0.5f;
        private Vector3 m_StartPosition;

        void Start()
        {
            buttonW = new MoveForwardCommand(moveTarget);            
            buttonS = new MoveBackCommand(moveTarget);            
            buttonA = new TurnLeftCommand(moveTarget);            
            buttonD = new TurnRightCommand(moveTarget);         

            m_StartPosition = moveTarget.transform.position;   
        }

        void Update()
        {
            if(m_IsReplaying)
            {
                return;
            }

            if(Input.GetKeyDown(KeyCode.W))
            {
                ExecuteNewCommand(buttonW);
            }
            else if(Input.GetKeyDown(KeyCode.S))
            {
                ExecuteNewCommand(buttonS);
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                ExecuteNewCommand(buttonA);
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                ExecuteNewCommand(buttonD);
            }

            else if(Input.GetKeyDown(KeyCode.U))
            {
                if(undoCommonds.Count==0)
                {
                    Debug.Log("还未执行命令无法Undo");
                    return;
                }

                Commmand lastCommand = undoCommonds.Pop();
                lastCommand.Undo();
                redoCommonds.Push(lastCommand);
            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                if(redoCommonds.Count==0)
                {
                    Debug.Log("命令无法Redo");
                    return;
                }
                Commmand nextCommand = redoCommonds.Pop();
                nextCommand.Execute();
                undoCommonds.Push(nextCommand);
            }else if(Input.GetKeyDown(KeyCode.Return))
            {
                m_IsReplaying = true;
                StartCoroutine(Replay());
            }
        }
        
        private IEnumerator Replay()
        {
            moveTarget.transform.position = m_StartPosition;

            yield return new WaitForSeconds(REPLAY_STEP_TIME);

            Commmand[] oldCommands = undoCommonds.ToArray();

            for (int i = 0; i < oldCommands.Length; i++)
            {
                Commmand nextCommand = oldCommands[i];
                
                nextCommand.Execute();

                yield return new WaitForSeconds(REPLAY_STEP_TIME);
            }
            m_IsReplaying = false;
        }

        private void ExecuteNewCommand(Commmand commmand)
        {
            if(commmand==null)
            {
                Debug.LogError("命名为空无法执行");
                return;
            }
            commmand.Execute();

            undoCommonds.Push(commmand);

            //执行新命令redo应该为空
            redoCommonds.Clear();
        }
    }
}