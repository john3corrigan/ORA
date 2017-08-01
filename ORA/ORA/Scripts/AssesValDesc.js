{
    var ProblemSolving = ["Unsatisfactory. Doesn't generate solutions to problems. Has insufficient problem-solving skills.",
        "Needs Improvement. Fails to completely analyze problems. Fails to identify underlying or systematic problems.",
        "Meets Expectations. Can analyze facts, information, and evidence logically. Recommends solutions to problems.",
        "Exceeds Expectations. Develops alternative solutions to problems.Recognizes similarities among situations and appropriately address them.",
        "Outstanding. Always address root cause in solutions. Identifies problems in own areas and develops resourceful solutions."];

    var ProfessionalismAndTeamwork = ["Unsatisfactory.Does not follow through  on commitments. Has consistently failed to achieve goals as team member.",
        "Needs Improvement. Tends to be difficult under pressure. Not seen as a team a team player.",
        "Meets Expectations. Follows professional Standard for the job.Dedicated to team goals.",
        "Exceeds Expectations. Treats people equally despite their differences. Creates strong Teams",
        "Outstanding. Shows expectational teamwork.Known by customers as honest and ethical."];

    var Attendance = ["Unsatisfactory. Breaks are long and too frequent. Has failed to call in sick ___ times",
        "Needs Improvement. Has missed the work without prior notification 10 times this year.Consistently uses all sick days.",
        "Meets Expectations. Consistently arrives at work on time.Attendance is satisfactory.",
        "Exceeds Expectations. Consistently arrives at work early.",
        "Outstanding. Never Misses work without prior and appropriate notification. Always at work and on time."];

    var ResourceUse = ["Unsatisfactory. Has damaged resources needs by others.Received complaints about hoarding resources.",
        "Needs Improvement. Takes resources without informing others",
        "Meets Expectations. Coordinates resource use with others. Returns resources so others can use.",
        "Exceeds Expectations.Suggests ways to save money and resources.",
        "Outstanding. Uses innovative ways to save .Has introduced cost- saving measures."];

    var AttitudeorApproachtoWork = ["Unsatisfactory. Always find fault in others. Presence often creates tension in groups.",
        "Needs Improvement. Can be negative. Projects \"in it for myself\" attitude.",
        "Meets Expectations. Cooperative and cordial. Always focuses on getting things done.",
        "Exceeds Expectations. Positive, contagious spirit.Team player.",
        "Outstanding. Views success in relation to groups success. Enthusiastic and Energetic."];

    var QualityofWork = ["Unsatisfactory.On multiple occassions, errors have caused work stoppage or rework.Quality is not a priority.",
        "Needs Improvement. Needs to focus on reducing error rate. Needs to apply training to improve quality outputs.",
        "Meets Expectations. Work is consistently error free. Quality of work meets standards.Works well with cutomers to assure quality.",
        "Exceeds Expectations. Leads team in reducing errors in work. Focuses on continuously improving quality.",
        "Outstanding. Takes special cautions to prevent errors. Consistently receives kudos for quality of work from customer."];

    var VerbalSkills = ["Unsatisfactory. Does not build audience participation when needed. Often misunderstands what others are saying.",
        "Needs Improvement. It is not confident when presenting. Reads scripts and has little contact with the audience.",
        "Meets Expectations. Can explain complicated procedures well. Uses collateral material effectively.",
        "Exceeds Expectations. Speaks articulately and concisely. Is convincing and confident when speaking.",
        "Outstanding. Builds interactivity with audience. Is an articulate spokesperson for team's view."];

    var EthicalBehavior = ["Unsatisfactory. Does not behave ethically. Actions have resulted in customers refusing to do business with us.",
        "Needs Improvement. Has Behaved unethically in dealing with clients. Sometimes sees ethics as an inconvenience.",
        "Meets Expectations. Is noated for honesty and fairness. Will not exploit loopholes in laws for benefits.",
        "Exceeds Expectations. Never lies or bends the truth.Knows and follows applicable laws.",
        "Outstanding. Always demonstrated integrity and honesty. Does what is right regardless of the consequences"];

    var FeedbackReceivingAndGiving = ["Unsatisfactory. Consistently takes feedback with negativity and disagreement. Consistently receives feedback denfensively and argumentatively.",
        "Needs Improvement. Tends to deliver feedback in an insensitive manner. Will criticize the person not his/ her actions.",
        "Meets Expectations. Usually receptive to feedback and appreciative. Works to learn from feedback received.",
        "Exceeds Expectations. Delivers feedback in a sensitive and caring way.Seeks to understand rather than defend against negative feedback.",
        "Outstanding. Welcomes feedback especially negative.Consistently receives feedback constructively. Always offers criticism in a constructive manner."];

    var GroomingAndAppearance = ["Unsatisfactory. Ignored requests to deal with appearance. Will often underdress for important meetings.",
        "Needs Improvement. Often has a sloppy appearance. Grooming and appearance needs to be improved.",
        "Meets Expectations. Shows a professional image. Comes work in proper attire.",
        "Exceeds Expectations. Has a polished appearance. Appears composed and professional.",
        "Outstanding. Impeccable dress and grooming.By appearance, represents our company extremely well."];

    var Productivity = ["Unsatisfactory. Production rate and quality are consistently low.One of the lowest producers in the department",
        "Needs Improvement. Quantity is acceptable, but quality is low. Needs to increase his/ her productivity rates.",
        "Meets Expectations. Track down problems that interface with productivity. Meets production goals while keeping quality high.",
        "Exceeds Expectations. Has helped others improve productivity. Frequently above standards in production.",
        "Outstanding .Produces more than anyone else in the department. Closed 98% of customers issues in first contact."];

    var WritteSkills = ["Unsatisfactory. Numerous errors and lack of organization make understanding difficult. Poor writer.",
        "Needs Improvement. The point of written communication not always clear. Takes long times to get to the point.",
        "Meets Expectations. Can express himself/herself clearly in written communication.",
        "Exceeds Expectations. Writes quickly, clearly and correctly. Translation of documentation were free of confusion.",
        "Outstanding. Exceptional communicator. Regularly receives positive feedback on clarity of writing."];

    var AbilityToMeetDeadlines = ["Unsatisfactory.Often misses the standard deadlines. Does not admit to being behind schedule.",
        "Needs Improvement. Missed deadlines more than once this year. Flustered when deadlines change.",
        "Meets Expectations. Meets deadlines well in periods of calm. Informs when delays are anticipated.",
        "Exceeds Expectations. Maintains quality with tight timelines. Seems to thrive on pressure deadlines.",
        "Outstanding. Consistently ahead of schedule."];

    var TechnicalMonitoringofJobSkills = ["Unsatisfactory. Not learning new skills.Doesn't pull resources together effectively.",
        "Needs Improvement. Has ability to learn, but seems disinterested in gaining proficiency.",
        "Meets Expectations. Picks up on technical skills quickly. Is good at learning new industry, company, or technical knowledge.",
        "Exceeds Expectations. Has natural ability to quickly comprehend instructions and apply new skills. Performs efficiently and well.",
        "Outstanding. Rapidly growing skills. Uses available resources to learn new skills."];

    var PersonalGrowth = ["Unsatisfactory. Denies existence of personal difficulties. Works suffers because of inability to balance work, family and outside interest.",
        "Needs Improvement. Work negatively impacted by personal issues.Overly sensitive to negative feedback.",
        "Meets Expectations. Regularly asks for feedback and responds by making an effort to improve.Seeks help as needed.",
        "Exceeds Expectations. Dramatic improvement in maturity over last two years. Helps other with personal growth.",
        "Outstanding. Demonstrates continues learning. Balances work and family/ outside interest."];

    var ProductKnowledge = ["Unsatisfactory. Presents incorrect product information to customer. Lacks critical product knowledge.",
        "Needs Improvement. Often needs help explaining some products.Often relies on customer expertise.",
        "Meets Expectations. Gives creditable product descriptions to most customers. Effectively troubleshoots product problems.",
        "Exceeds Expectations. Makes suggestions to improve product line. Has received positive comments from customers.",
        "Outstanding. Can explain product benefits to customers in ways that always address their problems.Often praised by customer for expertise."];

    var ListeningSkills = ["Unsatisfactory. Constantly interrupts. Not aware when he/she does not understand.",
        "Needs Improvement. Needs things explained several times.",
        "Meets Expectations. Follows directions accurately. Questions when unsure.",
        "Exceeds Expectations. Makes frequent use of active or reflective listening.",
        "Outstanding. Manage to appear attentive even in difficult situation."];

    var AbilityToOrganizeAndDetailWorkProcesses = ["Unsatisfactory. Spends too much time and energy working on issues that lack substance.",
        "Needs Improvement. May not anticipate or be able to see how multiple activities come together.",
        "Meets Expectations. Understands the origin and reasoning behind key policies, practices and procedures.",
        "Exceeds Expectations. Keeps track of multiple things at once.Stays organized under high pressure.",
        "Outstanding. Always  on top of things.Others rely on him/her to help stay organized."];

    var AskingAppropriateQuestions = ["Unsatisfactory. Does not know how to ask questions that will guide work.",
        "Needs Improvement. Lacks the ability to ask clarifying questions to resolve issues or obtain infomration or waits to long before asking.",
        "Meets Expectations. Able to appropriately ask critical questions in a timely manner and general in obtaining information.",
        "Exceeds Expectations. Has the ability to ask probing questions in order to retrieve additional information of the success of their projects.",
        "Outstanding. Consistently asks questions that gather detailed information critical to the success of projects and tasking of assignments."];

    var PotentialforAdvancement = ["Unsatisfactory. Cannot cope with complex decision making. Has not generated the confidence of others required for promotion.",
        "Needs Improvement. Unaware of areas that need improvement. Would require coaching in supervisory skills.",
        "Meets Expectations. Learns effectively over time. Willing to go the extra mile.",
        "Exceeds Expectations. Often helps solve other's problems  Pursues independent self-development.",
        "Outstanding. Has potential to advance to high levels in the organization. Effective leader without formal power."];
}
function Summary(place) {
    var $place = $(this)
    var val = $place.val();
    var location = place;
    $(this).appendChild(location[val]);
    
}