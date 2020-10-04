using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{

    public int currentStageIndex = 0;
    public Material selectedMat;

    public Transform cylinder;
    public StageController currentStage;

    private void Start()
    {
        SetNewStage();
    }
    public void StageComplete(StageController targetStage)
    {
        targetStage.CurrentLoop = false;
        targetStage.GetComponent<Rotator>().enabled = false;
        targetStage.GetComponentInChildren<Renderer>().material = LevelController.Instance.selectedMat;

        currentStageIndex++;
        StartCoroutine(FinishRotation(targetStage));


    }

    private IEnumerator FinishRotation(StageController targetStage)
    {
        Quaternion startRot = targetStage.transform.rotation;
        Quaternion endRot = Quaternion.LookRotation((cylinder.position - targetStage.transform.position).normalized);
        float elapsed = 0f;
        float duration = 0.3f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            targetStage.transform.rotation = Quaternion.Lerp(startRot, endRot, elapsed / duration);
            yield return null;
        }

        targetStage.transform.rotation = endRot;
        SetNewStage();

    }
    private void SetNewStage()
    {
        currentStage = transform.GetChild(currentStageIndex).GetComponent<StageController>();
        currentStage.CurrentLoop = true;
    }
}
