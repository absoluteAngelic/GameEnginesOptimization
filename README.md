# GameEnginesOptimization

### This project is a bunch of enemies that spawn every 0.3 seconds, and start moving towards the center of the stage, with 40 damage being done every 0.2 seconds within an OverlapSphere area in the center. Each test has a large lag spike near the end of the profiling due to the game actually ending and rendering the win screen, this is ignored for our performance testing. The goal is to test the difference that certain optimizations will make on the game's performance. All tests were done with the exact same things running on my computer.
---

Name: Luke Boctor<br>
Student #: 100927793

### Base Game:

The base game with no optimizations done seemed to have a peak CPU-time frame of 3.33ms. WaitForLastPresentationAndUpdateTime took the most time, followed by FinishFrameRendering, which are both default unity processes. ScriptRunBehaviourUpdate (Update loops of all my scripts) took 0.04ms.
<img width="944" height="524" alt="image" src="https://github.com/user-attachments/assets/68e8b98b-7b24-451a-8d17-493e2c67a396" />

Total Committed Memory was 0.56GB
<img width="924" height="258" alt="image" src="https://github.com/user-attachments/assets/ffb76145-11a3-404d-9f80-0272e4fa105e" />

When taking a sample over approximately 1350 "normal" frames, the median CPU-time was 1.825ms, with a minimum of 1.335ms.
<img width="272" height="82" alt="image" src="https://github.com/user-attachments/assets/e8edf512-1282-42f5-8bcd-d8f3bfe037a2" />

---

### Singletons:

After turning the GameManager and Player into singletons, so they could be gotten by instance instead of using GameObject.Find() on both of them for every spawned enemy, the peak CPU-time frame was 3.09ms. This time, WaitForLastPresentationAndUpdateTime took less time than FinishFrameRendering. ScriptRunBehaviourUpdate took 0.04ms again.
<img width="947" height="525" alt="image" src="https://github.com/user-attachments/assets/aabbfad2-13a5-4981-8bf5-3749d3a57ec3" />

Total Committed Memory was 0.59GB
<img width="928" height="257" alt="image" src="https://github.com/user-attachments/assets/9fcc5499-7167-4511-8c43-ef4d0eeeb4a9" />

When taking a sample over approximately 1400 frames, the median CPU-time was 1.822ms, with a minimum of 1.297ms.
<img width="283" height="102" alt="image" src="https://github.com/user-attachments/assets/a2384eb5-10ad-4b38-8da7-89c12d8aee81" />

---

### Dirty Flag:

After putting the enemy health check to see if it should die, and GameManager check to see if the game has been won outside of their Update() loops and into the method that lowers enemy health, and that tells the game manager another enemy has been killed, the peak CPU-time frame was 3.26ms. FinishRendering followed by WaitForLast took the most time. BehaviourUpdate was 0.04ms again.
<img width="949" height="523" alt="image" src="https://github.com/user-attachments/assets/6c511a07-852a-4015-a145-1dcb78982b12" />

Total Committed Memory was 0.57GB
<img width="928" height="259" alt="image" src="https://github.com/user-attachments/assets/7f2e9e7a-bc56-46ad-8689-9b483c9e7b11" />

When taking a sample over approximately 1300 frames, the median CPU-time was 1.871, with a minimum of 1.45ms.
<img width="278" height="103" alt="image" src="https://github.com/user-attachments/assets/3d886b2e-dc07-4c71-ba94-7b0e6e6c86da" />

---

### Object Pooling:

After implementing object pooling for the enemy spawning, the peak CPU-time frame was 3.28ms. FrameRendering, then WaitForLast took the most time. BehaviourUpdate 0.04ms again.
<img width="947" height="524" alt="image" src="https://github.com/user-attachments/assets/80b69018-e960-485a-a830-a72a188d8564" />

Total Committed Memory was 0.57GB
<img width="929" height="260" alt="image" src="https://github.com/user-attachments/assets/3a4695fc-2ddc-4253-9b21-11c3b4f7db70" />

When taking a sample over approximately 1400 frames, the median CPU-time was 1.81ms, with a minimum of 1.34ms.
<img width="282" height="102" alt="image" src="https://github.com/user-attachments/assets/64de9186-0d32-4408-8e83-7baaa4c9e33b" />

---

### Analysis:

-What did you notice was impacting the performance of your project?

I don't think there was anything significant to notice, the two significant CPU-time hogs were just unity actually keeping the game as a functional game, and nothing of note at all came from anywhere else.

-Which pattern(s) did you implement, and what behavior did they replace?

I implemented singletons for the GameManager and Player so they could be gotten by instance instead of using GameObject.Find() on both of them for every spawned enemy<br><br>
I implemented dirty flags for the Enemy checking its health, and for the GameManager checking if the game has been won. The check went outside of the Update() loop, and into the Enemy TakeHealth method, and GameManager EnemyKilled() method.<br><br>
I implemented object pooling for the enemy spawning, instead of instantiating and destroying them repeatedly.

-Do your patterns / technique implementations improve performance? Why or why not?

I don't believe anything that I implemented affected performance in any meaningful or noticeable way. This is most likely due to the game being so simple and easy to run; I imagine with a big game packed full of features and various scripts, these optimizations may have made a noticeable impact.

-Can you demonstrate what the profiling process revealed?

To be quite honest, I don't think the profiler revealed anything important about the performance of the game. It did reveal that the game is very very lightweight, even with many enemies moving at once and an OverlapSphere being done frequently.
