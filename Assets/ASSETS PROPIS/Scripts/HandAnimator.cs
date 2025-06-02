using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    /// <summary>
    /// Component which reads input values and drives the thumbstick, trigger, and grip transforms
    /// to animate a controller model.
    /// </summary>
    public class ControllerAnimator : MonoBehaviour
    {
      
        [SerializeField]
        XRInputValueReader<float> m_GripInput = new XRInputValueReader<float>("Grip");

        Animator handAnim=null;

        void OnEnable()
        {
           
            handAnim = GetComponent<Animator>();
           
            m_GripInput?.EnableDirectActionIfModeUsed();
        }

        void OnDisable()
        {
           
            m_GripInput?.DisableDirectActionIfModeUsed();
        }

        void Update()
        {

            if (m_GripInput != null)
            {
                var gripVal = m_GripInput.ReadValue();
                handAnim.SetFloat("ManoBlend", gripVal);
            }
        }
    }
}
