using System.Collections.Generic;

namespace AI
{
    public class Fsm
    {
        private FsmState _current;

        public Fsm(FsmState state)
        {
            _current = state;
            _current.Enter();
        }

        public void UpdateFsm()
        {
            FsmTransition transition = _current.VerifyTransition();

            if (transition != null)
            {
                _current.Exit();
                transition.Fire();
                _current = _current.NextState(transition);
                _current.Enter();
            }
            else
            {
                _current.Stay();
            }
        }
    }
    
    public delegate bool FsmCondition();

    public delegate void FsmAction();

    public class FsmTransition
    {
        public FsmCondition myCondition;
        
        public List<FsmAction> myActions = new List<FsmAction>();

        public FsmTransition(FsmCondition condition, FsmAction[] actions = null)
        {
            myCondition = condition;
            
            if(actions != null) 
                myActions.AddRange(actions);
        }

        public void Fire()
        {
            if(myActions == null)
                return;
                
            foreach (FsmAction action in myActions)
            {
                action();
            }
        }
    }

    public class FsmState
    {
        public List<FsmAction> enterActions = new List<FsmAction>();
        public List<FsmAction> stayActions = new List<FsmAction>();
        public List<FsmAction> exitActions = new List<FsmAction>();

        private Dictionary<FsmTransition, FsmState> links;

        public FsmState()
        {
            links = new Dictionary<FsmTransition, FsmState>();
        }

        public void AddTransition(FsmTransition transition, FsmState target)
        {
            links[transition] = target;
        }

        public FsmTransition VerifyTransition()
        {
            foreach (FsmTransition transition in links.Keys)
            {
                if (transition.myCondition()) return transition;
            }

            return null;
        }

        public FsmState NextState(FsmTransition transition)
        {
            return links[transition];
        }

        public void Enter()
        {
            foreach (FsmAction action in enterActions)
            {
                action();
            }
        }
        
        public void Stay()
        {
            foreach (FsmAction action in stayActions)
            {
                action();
            }
        }
        
        public void Exit()
        {
            foreach (FsmAction action in exitActions)
            {
                action();
            }
        }
    }
}